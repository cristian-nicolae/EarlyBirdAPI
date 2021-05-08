using System;
using System.ComponentModel.DataAnnotations;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class MessageDto
    {

        public int ConversationId { get; set; }


        public Guid SenderId { get; set; }

        public string Content { get; set; }
    }
}
