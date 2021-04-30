using EarlyBird.API.Hubs;
using EarlyBird.API.Models;
using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EarlyBird.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _chatHub;
        private readonly ITokenService _tokenService;
        private readonly IUsersService _usersService;


        public ChatController(IHubContext<ChatHub> chatHub,
                                ITokenService tokenService,
                                IUsersService usersService)
        {
            _chatHub = chatHub;
            _tokenService = tokenService;
            _usersService = usersService;
        }

        [HttpPost("messages")]
        [Authorize]
        public async Task Post(ChatMessage message)
        {
            var user = GetCurrentUser();
            message.User = user.Firstname;
            await _chatHub.Clients.User(user.Id.ToString()).SendAsync("ReceiveMessage", message);
        }

        #region private methods

        private ViewUserDto GetCurrentUser()
        {
            var userId = _tokenService.GetUserIdFromClaims(HttpContext.User.Identity as ClaimsIdentity);
            return _usersService.GetById(userId);
        }
        #endregion
    }
}
