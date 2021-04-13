using System;
using System.ComponentModel.DataAnnotations;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class AddReviewDto
    {   
        [Required]
        public Guid SenderId { get; set; }
        [Required]
        public Guid ReceiverId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        [Range(1,5)]
        [Required]
        public int Rating { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
