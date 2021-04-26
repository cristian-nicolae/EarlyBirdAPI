using EarlyBird.DataAccess.Utils;

namespace EarlyBird.API.Models
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Roles Role { get; set; }
    }
}
