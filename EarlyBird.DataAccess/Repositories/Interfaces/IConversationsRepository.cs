using EarlyBird.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EarlyBird.DataAccess.Repositories.Interfaces
{
    public interface IConversationsRepository
    {
        Task<ConversationEntity> GetByIdAsync(int id);
        Task<IEnumerable<ConversationEntity>> GetUserConversationsAsync(Guid userId);
        Task<ConversationEntity> AddAsync(ConversationEntity conversationEntity);

        Task UpdateNewMessageAsync(int conversationId, bool newMessage);
        Task<ConversationEntity> GetByUserIds(Guid id1, Guid id2);

    }
}
