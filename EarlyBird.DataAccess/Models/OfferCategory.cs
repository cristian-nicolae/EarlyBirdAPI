using System.ComponentModel.DataAnnotations;

namespace EarlyBird.DataAccess.Models
{
    public class OfferCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Offer Offer { get; set; }

        [Required]
        public Category Category { get; set; }
    }
}
