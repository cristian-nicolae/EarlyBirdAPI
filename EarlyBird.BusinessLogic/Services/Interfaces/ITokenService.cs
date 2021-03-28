using EarlyBird.BusinessLogic.DTOs;

namespace EarlyBird.BusinessLogic.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(UserDto user);
    }
}
