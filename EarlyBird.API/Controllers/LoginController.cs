using EarlyBird.API.Models;
using EarlyBird.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace EarlyBird.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UsersService usersService;

        public LoginController(UsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest credentials)
        {
            var token = usersService.Authenticate(credentials.Username, credentials.Password);
            if (token == null) return Forbid();
            return Ok(new LoginResponse { Token = token });
        }
    }
}
