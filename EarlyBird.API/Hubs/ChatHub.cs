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
    {}
}
