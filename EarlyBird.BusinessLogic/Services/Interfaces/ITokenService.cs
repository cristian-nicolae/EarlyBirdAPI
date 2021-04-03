using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.BusinessLogic.Utils;
using EarlyBird.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace EarlyBird.BusinessLogic.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(UserDto user);
        Guid GetUserIdFromClaims(ClaimsIdentity identity);
        Roles GetRoleFromClaims(ClaimsIdentity identity);
    }
}
