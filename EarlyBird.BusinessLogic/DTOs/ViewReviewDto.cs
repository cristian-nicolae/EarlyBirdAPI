using System;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class ViewReviewDto
    {
        public int Id { get; set; }

        public Guid SenderId { get; set; }
        public Guid Receiver { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
    }
}
