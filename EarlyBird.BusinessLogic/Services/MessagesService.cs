using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.BusinessLogic.Services
{
    public class MessagesService : IMessagesService
    {
        public Task<ViewMessageDto> AddAsync(MessageDto messageDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ViewMessageDto>> GetConversationMessagesAsync(int conversationId, int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}
