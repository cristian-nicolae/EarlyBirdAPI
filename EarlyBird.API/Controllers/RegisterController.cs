using EarlyBird.API.Models;
using EarlyBird.API.Utils;
using EarlyBird.BusinessLogic.Services;
using EarlyBird.BusinessLogic.Services.Interfaces;
using EarlyBird.DataAccess.Utils;
using Microsoft.AspNetCore.Mvc;

namespace EarlyBird.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUsersService usersService;

        public RegisterController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterRequest user)
        {
            if (user.Role == Roles.Admin)
                return Unauthorized();

            try
            {
                var token = usersService.Register(user.ToRegisterUserDto());
                return Ok(new RegisterResponse { Token = token });
            }
            catch (UsersService.UserAlreadyExistingException)
            {
                return BadRequest();
            }
        }
    }
}
