using System.ComponentModel.DataAnnotations;

namespace EarlyBird.DataAccess.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Cost { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Status { get; set; }
        
        [Required]
        public User PublisherId { get; set; }

        [MaxLength(500)]
        public string Prerequisites { get; set; }
        
        [MaxLength(500)]
        public string Notes { get; set; }


        public User AccepterId { get; set; }
    }
}
