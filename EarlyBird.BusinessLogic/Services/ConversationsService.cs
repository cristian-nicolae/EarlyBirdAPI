using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.BusinessLogic.Services
{
    public class ConversationsService : IConversationsService
    {
        public Task<ConversationViewDto> AddAsync(ConversationDto conversationDto)
        {
            throw new NotImplementedException();
        }

        public Task<ConversationViewDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ConversationViewDto>> GetUserConversationsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
