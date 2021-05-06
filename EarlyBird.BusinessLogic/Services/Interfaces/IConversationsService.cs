using EarlyBird.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EarlyBird.BusinessLogic.Services.Interfaces
{
    public interface IConversationsService
    {
        Task<ConversationViewDto> GetByIdAsync(int id);
        Task<IEnumerable<ConversationViewDto>> GetUserConversationsAsync(Guid userId);
        Task<ConversationViewDto> AddAsync(ConversationDto conversationDto);
    }
}
