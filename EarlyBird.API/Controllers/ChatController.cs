using EarlyBird.API.Hubs;
using EarlyBird.API.Models;
using EarlyBird.API.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;

namespace EarlyBird.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _chatHub;

        public ChatController(IHubContext<ChatHub> chatHub)
        {
            _chatHub = chatHub;
        }

        [HttpPost("messages")]
        [Authorize]
        public async Task Post(ChatMessage message)
        {
            // run some logic...

            await _chatHub.Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
