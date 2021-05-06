using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EarlyBird.DataAccess.Repositories
{
    public class MessagesRepository : IMessagesRepository
    {
        public Task<MessageEntity> AddAsync(MessageEntity messageEntity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MessageEntity>> GetConversationMessagesAsync(int conversationId, int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}
