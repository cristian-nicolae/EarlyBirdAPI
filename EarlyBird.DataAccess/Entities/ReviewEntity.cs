using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EarlyBird.DataAccess.Entities
{
    public class ReviewEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        
        [Required]
        [Column(TypeName = "tinyint")]
        public int Rating { get; set; }
        
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [ForeignKey("ReceiverId")]
        public Guid ReceiverId { get; set; }

        public UserEntity Receiver { get; set; }
   
        [Required]
        [ForeignKey("SenderId")]
        public Guid SenderId { get; set; }

        public UserEntity Sender { get; set; }

    }
}
