namespace EarlyBird.BusinessLogic.DTOs
{
    public class ViewOfferCategoryDto
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public ViewCategoryDto Category { get; set; }
    }
}
