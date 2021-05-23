using EarlyBird.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EarlyBird.DataAccess.Repositories.Interfaces
{
    public interface IMessagesRepository
    {
        Task<IEnumerable<MessageEntity>> GetConversationMessagesAsync(int conversationId, int pageSize, int pageNumber);
        Task<IEnumerable<MessageEntity>> GetConversationMessagesAsync(int conversationId);
        Task<MessageEntity> AddAsync(MessageEntity messageEntity);
    }
}
