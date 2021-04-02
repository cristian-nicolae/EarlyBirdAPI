using EarlyBird.BusinessLogic.Utils;
using System;


namespace EarlyBird.BusinessLogic.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public Roles? Role { get; set; }

    }
}
