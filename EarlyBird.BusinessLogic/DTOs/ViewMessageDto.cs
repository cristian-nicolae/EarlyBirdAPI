using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class ViewMessageDto
    {
        public int Id { get; set; }


        public int ConversationId { get; set; }

        public ConversationViewDto ConversationViewDto { get; set; }


        public Guid SenderId { get; set; }


        public string Content { get; set; }
    }
}
