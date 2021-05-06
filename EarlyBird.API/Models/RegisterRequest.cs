using EarlyBird.DataAccess.Utils;
using System.ComponentModel.DataAnnotations;

namespace EarlyBird.API.Models
{
    public class RegisterRequest
    {
        [Required]
        [MinLength(1)]
        public string Username { get; set; }
        [Required]
        [MinLength(4)]
        public string Password { get; set; }
        [Required]
        [MinLength(1)]
        public string Firstname { get; set; }
        [Required]
        [MinLength(1)]
        public string Lastname { get; set; }
        [Required]
        [Range(2, 3)]
        public Roles Role { get; set; }
    }
}
