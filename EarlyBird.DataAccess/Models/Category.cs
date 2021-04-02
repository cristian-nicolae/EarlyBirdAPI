using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EarlyBird.DataAccess.Models
{
    public class Category
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public ICollection<OfferCategory> OfferCategories { get; set; }
    }
}
