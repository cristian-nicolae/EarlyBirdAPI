using System;
using System.ComponentModel.DataAnnotations;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class ConversationDto
    {
        [Required]
        public Guid FirstId { get; set; }

        [Required]
        public Guid SecondId { get; set; }

    }
}
