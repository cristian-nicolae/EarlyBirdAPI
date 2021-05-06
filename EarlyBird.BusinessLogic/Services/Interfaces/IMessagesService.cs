using EarlyBird.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.BusinessLogic.Services.Interfaces
{
    public interface IMessagesService
    {
        Task<IEnumerable<ViewMessageDto>> GetConversationMessagesAsync(int conversationId, int pageSize, int pageNumber);
        Task<ViewMessageDto> AddAsync(MessageDto messageDto);
    }
}
