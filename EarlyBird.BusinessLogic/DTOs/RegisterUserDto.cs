using EarlyBird.DataAccess.Utils;
using System.ComponentModel.DataAnnotations;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class RegisterUserDto
    {
        [Required]
        [MaxLength(200)]
        public string Username { get; set; }

        [Required]
        [MaxLength(200)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(200)]
        public string Lastname { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(200)]
        public string Password { get; set; }
        [Required]
        [Range(2,3)]
        public Roles Role { get; set; }
    }
}
