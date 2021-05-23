using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarlyBird.DataAccess.Repositories
{
    public class MessagesRepository : IMessagesRepository
    {

        private readonly EarlyBirdContext context;

        public MessagesRepository(EarlyBirdContext context)
        {
            this.context = context;
        }

        public async Task<MessageEntity> AddAsync(MessageEntity messageEntity)
        {
            await context.AddAsync(messageEntity);
            await context.SaveChangesAsync();
            return messageEntity;
        }

        public async Task<IEnumerable<MessageEntity>> GetConversationMessagesAsync(int conversationId, int pageSize, int pageNumber)
        {
           return await context.Messages
            .Where(x => x.ConversationId == conversationId)
            .OrderByDescending(x => x.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
            
        }

        public async Task<IEnumerable<MessageEntity>> GetConversationMessagesAsync(int conversationId)
        {
            return await context.Messages
             .Where(x => x.ConversationId == conversationId)
             .OrderByDescending(x => x.Id)
             .ToListAsync();

        }
    }
}
