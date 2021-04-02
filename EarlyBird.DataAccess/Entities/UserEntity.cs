using EarlyBird.BusinessLogic.Utils;
using System;

namespace EarlyBird.DataAccess.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public Roles? Role { get; set; }
    }
}
