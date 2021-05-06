using System;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class ConversationViewDto
    {

        public int Id { get; set; }
        public bool NewMessage { get; set; }

        public ViewUserDto First { get; set; }

        public ViewUserDto Second { get; set; }

        public Guid FirstId { get; set; }

        public Guid SecondId { get; set; }
    }
}
