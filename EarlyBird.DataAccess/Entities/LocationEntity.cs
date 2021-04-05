using System.ComponentModel.DataAnnotations;

namespace EarlyBird.DataAccess.Entities
{
    public class LocationEntity
    {
        [Key]
        public int Id { get; set; }
        
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
