using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EarlyBird.DataAccess.Entities
{
    public class OfferCategoryEntity
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("OfferId")]
        public int OfferId { get; set; }

        public OfferEntity Offer { get; set; }

        [Required]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public CategoryEntity Category { get; set; }
    }
}
