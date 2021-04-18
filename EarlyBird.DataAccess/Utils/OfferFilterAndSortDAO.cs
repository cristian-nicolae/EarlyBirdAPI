using System;
using System.Collections.Generic;

namespace EarlyBird.DataAccess.Utils
{
    public class OfferFilterAndSortDAO
    {
        public string Text { get; set; }

        public bool? TitleAscending { get; set; }

        public bool? CostAscending { get; set; }

        public int? MaxCost { get; set; }

        public int? MinCost { get; set; }

        public List<int> CategoryIds { get; set; }

        public List<string> Cities { get; set; }

        public OfferStatus? OfferStatus { get; set; }

        public bool? IsPublisher { get; set; }

        public Guid? UserId { get; set; }

    }
}