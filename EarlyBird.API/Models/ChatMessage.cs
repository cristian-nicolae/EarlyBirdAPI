using System;
using System.ComponentModel.DataAnnotations;

namespace EarlyBird.API.Models
{
    public class ChatMessage
    {
        [Required]
        public Guid ReceiverId { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Message { get; set; }

        [Required]
        public int ConversationId { get; set; }
    }
}
