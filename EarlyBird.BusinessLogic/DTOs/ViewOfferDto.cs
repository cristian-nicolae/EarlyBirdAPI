using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class ViewOfferDto
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Cost { get; set; }
        
        [JsonConverter(typeof(JsonStringEnumConverter))]

        public OfferStatus Status { get; set; }

        public Guid PublisherId { get; set; }
        
        public ViewUserDto Publisher { get; set; }

        public int LocationId { get; set; }

        public ViewLocationDto Location { get; set; }

        public string Prerequisites { get; set; }

        public string Notes { get; set; }

        public Guid? AccepterId { get; set; }

        public IEnumerable<ViewOfferCategoryDto> Categories { get; set; }

    }
}
