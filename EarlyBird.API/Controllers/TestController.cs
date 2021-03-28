using EarlyBird.API.Models;
using EarlyBird.BusinessLogic.Services.Interfaces;
using EarlyBird.BusinessLogic.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EarlyBird.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IUsersService usersService;

        public TestController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest credentials)
        {
            var token = usersService.Authenticate(credentials.Username, credentials.Password);
            if (token == null) return Unauthorized();
            return Ok(new LoginResponse { Token = token });
        }

        [HttpGet]
        [Authorize(Policy = Constants.Policies.Admin)]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
