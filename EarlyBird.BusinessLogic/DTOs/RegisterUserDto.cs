using EarlyBird.BusinessLogic.Utils;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class RegisterUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
    }
}
