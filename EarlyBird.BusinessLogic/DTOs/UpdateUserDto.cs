using System.ComponentModel.DataAnnotations;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class UpdateUserDto
    {
        [MaxLength(200)]
        public string Firstname { get; set; }

        [MaxLength(200)]
        public string Lastname { get; set; }

        [MinLength(4)]
        [MaxLength(200)]
        public string Password { get; set; }

    }
}
