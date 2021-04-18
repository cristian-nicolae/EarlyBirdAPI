using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class OfferFilterAndSort
    {
        public string Text { get; set; }

        public bool? TitleAscending { get; set; }

        public bool? CostAscending { get; set; }

        public int? MaxCost { get; set; }

        public int? MinCost { get; set; }
        [FromQuery(Name = "categoryIds[]")]
        public List<int> CategoryIds { get; set; }
        [FromQuery(Name = "cities[]")]
        public List<string> Cities { get; set; }

        public OfferStatus? OfferStatus { get; set; }

        public bool? FilterByCurrentUser { get; set; }

    }
}
