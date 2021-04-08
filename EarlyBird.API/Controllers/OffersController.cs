using EarlyBird.API.Utils;
using EarlyBird.BusinessLogic.Services;
using EarlyBird.BusinessLogic.Services.Interfaces;
using EarlyBird.DataAccess.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using EarlyBird.BusinessLogic.DTOs;

namespace EarlyBird.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOffersService offersService;
        private readonly ITokenService tokenService;

        public OffersController(IOffersService offersService, ITokenService tokenService)
        {
            this.offersService = offersService;
            this.tokenService = tokenService;
        }

        [HttpGet]
        [Route("{offerId}")]
        [Authorize(Policy = Policies.All)]
        public IActionResult GetById([FromRoute] int offerId)
        {
            var offer = offersService.GetById(offerId);
            if (offer == null) return NotFound();
            return Ok(offer);
        }

        [HttpGet]
        [Authorize(Policy = Policies.All)]
        public IActionResult GetAllByStatus([FromQuery] OfferStatus offerStatus)
        {
            var offers = offersService.GetAllByStatus(offerStatus);
            if (offers == null) return NotFound();
            return Ok(offers);
        }

        [HttpPost]
        [Authorize(Policy = Policies.Publisher)]
        public IActionResult AddOffer([FromBody] AddOfferDto addOfferDto)
        {
            addOfferDto.PublisherId = returnLoggedUserId();
            var result = offersService.Add(addOfferDto);
            var path = "api/offers/" + result.Id;

            return Created(path, result);
        }

        [HttpDelete]
        [Route("{offerId}")]
        [Authorize(Policy = Policies.Publisher)]
        public IActionResult DeleteOffer([FromRoute] int offerId)
        {
            if (!claimIdMatches(offersService.GetPublisherId(offerId))) return Forbid();
            return offersService.Delete(offerId) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        [Route("{offerId}")]
        [Authorize(Policy = Policies.Publisher)]
        public IActionResult UpdateOffer([FromRoute] int offerId, [FromBody] UpdateOfferDto offer)
        {
            if (!claimIdMatches(offersService.GetPublisherId(offerId))) return Forbid();
            offer.PublisherId = returnLoggedUserId();
            return offersService.Update(offerId, offer) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        private bool claimIdMatches(Guid userId)
        {
            return userId == tokenService.GetUserIdFromClaims(HttpContext.User.Identity as ClaimsIdentity);
        }

        private Guid returnLoggedUserId()
        {
            return tokenService.GetUserIdFromClaims(HttpContext.User.Identity as ClaimsIdentity);
        }

    }
}