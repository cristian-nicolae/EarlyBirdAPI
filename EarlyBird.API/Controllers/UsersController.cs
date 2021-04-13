using EarlyBird.API.Utils;
using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.BusinessLogic.Services;
using EarlyBird.BusinessLogic.Services.Interfaces;
using EarlyBird.DataAccess.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using static EarlyBird.BusinessLogic.Services.UsersService;

namespace EarlyBird.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;
        private readonly ITokenService tokenService;

        public UsersController(IUsersService usersService, ITokenService tokenService)
        {
            this.usersService = usersService;
            this.tokenService = tokenService;
        }

        [HttpGet]
        [Authorize(Policy = Policies.Admin)]
        public IActionResult GetAll() 
        {
            return Ok(usersService.GetAll());
        }

        [HttpGet]
        [Route("{userId}")]
        [Authorize(Policy = Policies.All)]
        public IActionResult GetById([FromRoute] Guid userId)
        {
            var user = usersService.GetById(userId);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpDelete]
        [Route("{userId}")]
        [Authorize(Policy = Policies.All)]
        public IActionResult Delete([FromRoute] Guid userId)
        {
            if (!claimIdMatches(userId) && !isUserAdmin()) return Forbid();

            try
            {
                bool succeed = usersService.Delete(userId);
                if (succeed) return Ok();
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (UsersService.UserNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);
            try
            {
                if (!claimIdMatches(usersService.GetById(id).Id) && !isUserAdmin())
                    return Forbid();
                if (usersService.Update(id, updateUserDto))
                    return Ok();
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }


        private bool claimIdMatches(Guid userId)
        {
            return userId == tokenService.GetUserIdFromClaims(HttpContext.User.Identity as ClaimsIdentity);
        }
        private bool isUserAdmin()
        {
            return Roles.Admin == tokenService.GetRoleFromClaims(HttpContext.User.Identity as ClaimsIdentity);
        }
    }
}
