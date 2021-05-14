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
using static EarlyBird.BusinessLogic.Services.OffersService;
using EarlyBird.API.Models;

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
            try
            {
                var offer = offersService.GetById(offerId);
                return Ok(offer);
            }
            catch (OfferNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Authorize(Policy = Policies.All)]
        public IActionResult GetAllOffers([FromQuery] OfferFilterAndSort offerFilterQuery)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);
            return Ok(offersService.GetAllOffers(offerFilterQuery, HttpContext.User.Identity as ClaimsIdentity));
        }

        [HttpPost]
        [Authorize(Policy = Policies.Publisher)]
        public IActionResult AddOffer([FromBody] AddOfferDto addOfferDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

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
            try
            {
                if (!claimIdMatches(offersService.GetPublisherId(offerId))) return Forbid();
                return offersService.Delete(offerId) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (OfferNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{offerId}")]
        [Authorize(Policy = Policies.Publisher)]
        public IActionResult UpdateOffer([FromRoute] int offerId, [FromBody] UpdateOfferDto offer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);
            try
            {
                if (!claimIdMatches(offersService.GetPublisherId(offerId))) return Forbid();
                offer.PublisherId = returnLoggedUserId();
                return offersService.Update(offerId, offer) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (OfferNotFoundException)
            {
                return NotFound();
            }

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