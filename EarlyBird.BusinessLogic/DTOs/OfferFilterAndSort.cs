using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class OfferFilterAndSort
    {
        [MaxLength(1000)]
        public string Text { get; set; }

        public bool? TitleAscending { get; set; }

        public bool? CostAscending { get; set; }

        public int? MaxCost { get; set; }

        public int? MinCost { get; set; }

        [FromQuery(Name = "categoryIds[]")]
        public List<int> CategoryIds { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        public OfferStatus? OfferStatus { get; set; }

        public bool? FilterByCurrentUser { get; set; }

    }
}
