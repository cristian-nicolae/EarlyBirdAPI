using System;
using System.ComponentModel.DataAnnotations;

namespace EarlyBird.DataAccess.Entities
{
    public class MessageEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ConversationId { get; set; }

        [Required]
        public ConversationEntity ConversationEntity { get; set; }
        
        [Required]
        public Guid SenderId { get; set; }

        [Required]
        public UserEntity Sender { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Content { get; set; }
    }
}
