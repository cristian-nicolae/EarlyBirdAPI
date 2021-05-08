using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.BusinessLogic.Services.Interfaces;
using EarlyBird.BusinessLogic.Utils;
using EarlyBird.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarlyBird.BusinessLogic.Services
{
    public class ConversationsService : IConversationsService
    {

        private readonly IConversationsRepository conversationsRepository;

        public ConversationsService(IConversationsRepository conversationsRepository)
        {
            this.conversationsRepository = conversationsRepository;
        }

        public async Task<ConversationViewDto> AddAsync(ConversationDto conversationDto)
        {
            var result = await conversationsRepository.AddAsync(conversationDto.ToConversationEntity());
            return result?.ToConversationViewDto();
            
        }

        public async Task<ConversationViewDto> GetByIdAsync(int id)
        {
            return (await conversationsRepository.GetByIdAsync(id))?.ToConversationViewDto();
        }

        public async Task<IEnumerable<ConversationViewDto>> GetUserConversationsAsync(Guid userId)
        {
            return (await conversationsRepository.GetUserConversationsAsync(userId))
                .Select(x => x.ToConversationViewDto());
        }

    }
}
