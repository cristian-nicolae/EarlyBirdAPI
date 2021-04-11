using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.BusinessLogic.Services.Interfaces;
using EarlyBird.DataAccess.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using static EarlyBird.BusinessLogic.Services.ReviewsService;

namespace EarlyBird.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsService reviewsService;
        private readonly ITokenService tokenService;
        private readonly IUsersService usersService;

        public ReviewsController(
            IReviewsService reviewsService,
            ITokenService tokenService,
            IUsersService usersService)
        {
            this.reviewsService = reviewsService;
            this.tokenService = tokenService;
            this.usersService = usersService;
        }

        [HttpGet]
        public IActionResult GetAllUserReviews([FromQuery] Guid? receiverId)
        {
            if (receiverId == null && !isUserAdmin())
                return Forbid();
            return receiverId == null ? Ok(reviewsService.GetAll()) 
                : Ok(reviewsService.GetReviewsForReceiver((Guid)receiverId));
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetReviewById([FromRoute] int id)
        {
            var result = reviewsService.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteReview([FromRoute] int id)
        {
            try
            {
                if (!claimIdMatches(reviewsService.GetSenderId(id)) && !isUserAdmin())
                    return Forbid();
                if (reviewsService.Delete(id))
                    return Ok();
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (ReviewNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateReview([FromRoute] int id, [FromBody] UpdateReviewDto updateReviewDto)
        {
            try
            {
                if (!claimIdMatches(reviewsService.GetSenderId(id)) && !isUserAdmin())
                    return Forbid();
                if (reviewsService.Update(id, updateReviewDto))
                    return Ok();
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (ReviewNotFoundException)
            {
                return NotFound();
            }
        }
        
        [HttpPost]
        public IActionResult AddReview([FromBody] AddReviewDto addReviewDto)
        {
            addReviewDto.SenderId = getCurrentUserId();
            if (!usersService.UserExists(addReviewDto.ReceiverId)
                || addReviewDto.ReceiverId == addReviewDto.SenderId)
                return BadRequest();
            var review = reviewsService.Add(addReviewDto);
            return Created("api/reviews/" + review.Id, review);
        }


        private bool claimIdMatches(Guid userId)
        {
            return userId == getCurrentUserId();
        }
        private bool isUserAdmin()
        {
            return Roles.Admin == tokenService.GetRoleFromClaims(HttpContext.User.Identity as ClaimsIdentity);
        }

        private Guid getCurrentUserId()
        {
            return tokenService.GetUserIdFromClaims(HttpContext.User.Identity as ClaimsIdentity);
        }
    }
}
