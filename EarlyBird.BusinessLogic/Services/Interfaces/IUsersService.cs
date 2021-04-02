
using EarlyBird.BusinessLogic.DTOs;

namespace EarlyBird.BusinessLogic.Services.Interfaces
{
    public interface IUsersService
    {
        string Authenticate(string username, string password);
        public string Register(RegisterUserDto registerUserDto);

    }
}
