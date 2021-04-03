using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EarlyBird.DataAccess.Entities
{
    public class CategoryEntity
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public ICollection<OfferCategoryEntity> Offers { get; set; }
    }
}
