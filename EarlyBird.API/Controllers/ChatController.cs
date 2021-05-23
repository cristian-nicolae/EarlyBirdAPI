using EarlyBird.API.Hubs;
using EarlyBird.API.Models;
using EarlyBird.API.Utils;
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
        private readonly IMessagesService _messagesService;

        public ChatController(IHubContext<ChatHub> chatHub,
                                ITokenService tokenService,
                                IUsersService usersService,
                                IConversationsService conversationsService,
                                IMessagesService messagesService)
        {
            _chatHub = chatHub;
            _tokenService = tokenService;
            _usersService = usersService;
            _conversationsService = conversationsService;
            _messagesService = messagesService;
        }


        [HttpGet("conversations/{conversationId}/messages")]
        [Authorize]
        public async Task<IActionResult> GetMessages([FromRoute] int conversationId, [FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            var conversation = await _conversationsService.GetByIdAsync(conversationId);
            if (conversation == null)
                return NotFound();

            var currentUser = GetCurrentUser();
            if (currentUser.Id != conversation.FirstId && currentUser.Id != conversation.SecondId)
                return Forbid();

            if (pageSize <= 0 || pageNumber <= 0)
            {
                pageSize = 10;
                pageNumber = 1;
            }

            var messages = await _messagesService.GetConversationMessagesAsync(conversationId, pageSize, pageNumber);
            if(pageNumber == 1)
                await _conversationsService.UpdateNewMessageAsync(conversationId, false);
            return Ok(messages);
        }

        [HttpGet("conversations")]
        [Authorize]
        public async Task<IActionResult> GetConversationsForCurrentUser()
        {
            var currentUser = GetCurrentUser();
            var conversations = await _conversationsService.GetUserConversationsAsync(currentUser.Id);
            return Ok(conversations);
        }

        [HttpPost("conversations/{conversationId}/messages")]
        [Authorize]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessage message, [FromRoute] int conversationId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var conversation = await _conversationsService.GetByIdAsync(conversationId);
            if (conversation == null)
                return NotFound();

            var currentUser = GetCurrentUser();
            if (currentUser.Id != conversation.FirstId && currentUser.Id != conversation.SecondId)
                return Forbid();
       
            var clientTask = _chatHub.Clients
                .User(message.ReceiverId.ToString())
                .SendAsync("ReceiveMessage",new { message = message.Message, conversationId });

            var saveMessageTask = _messagesService.AddAsync(message.ToMessageDto(currentUser.Id, conversationId));
            await clientTask;
            var newMessage = await saveMessageTask;
            await _conversationsService.UpdateNewMessageAsync(conversationId, true);

            return Ok(newMessage);
        } 

        [HttpPost("conversations")]
        [Authorize]
        public async Task<IActionResult> CreateConversation([FromBody] ConversationDto conversationDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var currentUser = GetCurrentUser();
            if (currentUser.Id != conversationDto.FirstId && currentUser.Id != conversationDto.SecondId)
                return Forbid();

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
