using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class AddOfferDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public double Cost { get; set; }

        [Required]
        public OfferStatus Status { get; set; }

        public Guid PublisherId { get; set; }

        public AddLocationDto Location { get; set; }

        [MaxLength(500)]
        public string Prerequisites { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

    }
}
