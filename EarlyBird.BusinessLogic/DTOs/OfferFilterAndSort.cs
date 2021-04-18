

namespace EarlyBird.BusinessLogic.DTOs
{
    public class OfferFilterAndSort
    {
        public string Text { get; set; }

        public bool? TitleAscending { get; set; }

        public bool? CostAscending { get; set; }

        public int? MaxCost { get; set; }

        public int? MinCost { get; set; }

        public int? CategoryId { get; set; }

        public string City { get; set; }

        public OfferStatus? OfferStatus { get; set; }

        public bool? FilterByCurrentUser { get; set; }

    }
}
