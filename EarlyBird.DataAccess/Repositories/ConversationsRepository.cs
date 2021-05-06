using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EarlyBird.DataAccess.Repositories
{
    public class ConversationsRepository : IConversationsRepository
    {
        public Task<ConversationEntity> AddAsync(ConversationEntity conversationEntity)
        {
            throw new NotImplementedException();
        }

        public Task<ConversationEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ConversationEntity>> GetUserConversationsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
