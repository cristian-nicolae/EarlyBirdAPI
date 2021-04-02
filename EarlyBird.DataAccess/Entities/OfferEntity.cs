using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EarlyBird.DataAccess.Entities
{
    public class OfferEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public double Cost { get; set; }

        [Required]
        public OfferStatus Status { get; set; }

        [Required]
        [ForeignKey("PublisherId")]
        public Guid PublisherId { get; set; }

        public UserEntity Publisher { get; set; }

        [Required]
        [ForeignKey("LocationId")]
        public int LocationId { get; set; }
        
        public LocationEntity Location { get; set; }


        [MaxLength(500)]
        public string Prerequisites { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

        [ForeignKey("AccepterId")]
        public Guid AccepterId { get; set; }

        public UserEntity Accepter { get; set; }

        public ICollection<OfferCategoryEntity> Categories { get; set; }
    }
}
