using EarlyBird.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EarlyBird.API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsService reviewsService;
        public ReviewsController(IReviewsService reviewsService)
        {
            this.reviewsService = reviewsService;
        }

        [HttpGet]
        public IActionResult GetAllUserReviews()
        {
            var result = reviewsService.GetReviewsForReceiver();
            return Ok(result);
        }

    }
}
