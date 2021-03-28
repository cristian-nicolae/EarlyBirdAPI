using EarlyBird.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.BusinessLogic.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(UserDto user);
    }
}
