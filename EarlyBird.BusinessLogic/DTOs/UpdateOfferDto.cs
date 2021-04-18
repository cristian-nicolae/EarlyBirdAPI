using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class UpdateOfferDto
    {
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public double Cost { get; set; }

        public Guid PublisherId { get; set; }

        public OfferStatus Status { get; set; }

        public AddLocationDto Location { get; set; }

        [MaxLength(500)]
        public string Prerequisites { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

    }
}
