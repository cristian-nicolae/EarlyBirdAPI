using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class UpdateReviewDto
    {
        [MaxLength(100)]
        public string Title { get; set; }

        public int Rating { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
