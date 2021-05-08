using EarlyBird.API.Hubs;
using EarlyBird.API.Models;
using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EarlyBird.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _chatHub;
        private readonly ITokenService _tokenService;
        private readonly IUsersService _usersService;
        private readonly IConversationsService _conversationsService;

        public ChatController(IHubContext<ChatHub> chatHub,
                                ITokenService tokenService,
                                IUsersService usersService,
                                IConversationsService conversationsService)
        {
            _chatHub = chatHub;
            _tokenService = tokenService;
            _usersService = usersService;
            _conversationsService = conversationsService;
        }

        [HttpPost("messages")]
        [Authorize]
        public async Task<IActionResult> SendMessage(ChatMessage message)
        {
           // await _chatHub.Clients.User(message.ReceiverId.ToString()).SendAsync("ReceiveMessage", message);
        } 
        [HttpPost("conversations")]
        [Authorize]
        public async Task<IActionResult> CreateConversation(ConversationDto conversationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);
            var conversation = await _conversationsService.AddAsync(conversationDto);
            if (conversation == null)
                return StatusCode(StatusCodes.Status500InternalServerError);
            string uri = $"/api/conversations/{conversation.Id}";
            return Created(uri, conversation);
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
