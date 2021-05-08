using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace EarlyBird.API.Hubs
{
    [Authorize]
    public class ChatHub: Hub
    {
    }
}
