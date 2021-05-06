using System;
using System.ComponentModel.DataAnnotations;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class MessageDto
    {

        [Required]
        public int ConversationId { get; set; }


        [Required]
        public Guid SenderId { get; set; }


        [Required]
        [MaxLength(2000)]
        public string Content { get; set; }
    }
}
