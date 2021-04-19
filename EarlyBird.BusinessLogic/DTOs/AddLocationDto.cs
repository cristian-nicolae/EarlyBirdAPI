using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class AddLocationDto
    {
        [Required]
        [MaxLength(100)]
        public string CityName { get; set; }

        [Required]
        [MaxLength(200)]
        public string StreetName { get; set; }

        [Required]
        [MaxLength(100)]
        public string StreetNumber { get; set; }

    }
}
