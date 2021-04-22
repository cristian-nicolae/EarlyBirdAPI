using System;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class ViewReviewDto
    {
        public int Id { get; set; }

        public Guid SenderId { get; set; }
        public ViewUserDto Sender { get; set; }
        public Guid ReceiverId { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
    }
}
