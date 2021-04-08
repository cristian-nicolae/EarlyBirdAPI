using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class AddOfferDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public double Cost { get; set; }

        public OfferStatus Status { get; set; }

        public Guid PublisherId { get; set; }

        public AddLocationDto Location { get; set; }

        public string Prerequisites { get; set; }

        public string Notes { get; set; }

        public Guid? AccepterId { get; set; }

    }
}
