﻿using System;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class AddReviewDto
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
    }
}
