using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EarlyBird.API.Hubs
{
    [Authorize]
    public class ChatHub: Hub
    {
        private readonly ITokenService _tokenService;
        private readonly IConnectedUsersService _connectedUsersService;
        private readonly ILogger<ChatHub> _logger;

        public ChatHub(ITokenService tokenService, IConnectedUsersService connectedUsersService, ILogger<ChatHub> logger)
        {
            _tokenService = tokenService;
            _connectedUsersService = connectedUsersService;
            _logger = logger;
        }

        public override async Task OnConnectedAsync()
        {
            _connectedUsersService.Add(GetCurrentUserId(), Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _connectedUsersService.Remove(GetCurrentUserId(), Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        #region private methods

        private Guid GetCurrentUserId()
        {
            return _tokenService.GetUserIdFromClaims(Context.User.Identity as ClaimsIdentity);
        }
        #endregion
    }
}
