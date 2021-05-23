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
    public class MessagesService : IMessagesService
    {
        private readonly IMessagesRepository messagesRepository;

        public MessagesService(IMessagesRepository messagesRepository)
        {
            this.messagesRepository = messagesRepository;
        }

        public async Task<ViewMessageDto> AddAsync(MessageDto messageDto)
        {
            var result = await messagesRepository.AddAsync(messageDto.ToMessageEntity());
            return result?.ToViewMessageDto();
        }

        public async Task<IEnumerable<ViewMessageDto>> GetConversationMessagesAsync(int conversationId, int pageSize, int pageNumber)
        {
            if (pageSize <= 0 || pageNumber <= 0)
            {
                return (await messagesRepository.GetConversationMessagesAsync(conversationId))
                    .Select(x => x.ToViewMessageDto());
            }

            return (await messagesRepository.GetConversationMessagesAsync(conversationId, pageSize, pageNumber))
                .Select(x => x.ToViewMessageDto());
        }
    }
}
