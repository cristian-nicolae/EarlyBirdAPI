using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class UpdateReviewDto
    {
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
    }
}
