using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarlyBird.DataAccess.Repositories
{
    public class ConversationsRepository : IConversationsRepository
    {
        private readonly EarlyBirdContext context;

        public ConversationsRepository(EarlyBirdContext context)
        {
            this.context = context;
        }

        public async Task<ConversationEntity> AddAsync(ConversationEntity conversationEntity)
        {
            await context.AddAsync(conversationEntity);
            await context.SaveChangesAsync();
            return conversationEntity;
        }

        public async Task<ConversationEntity> GetByIdAsync(int id)
        {
            return await context.Conversations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ConversationEntity>> GetUserConversationsAsync(Guid userId)
        {
            return await context.Conversations
                .Where(x => x.FirstId == userId || x.SecondId == userId)
                .OrderByDescending(x => x.NewMessage)
                .ToListAsync();
        }

        public async Task UpdateNewMessageAsync(int conversationId, bool newMessage)
        {
            var conversation = await GetByIdAsync(conversationId);
            conversation.NewMessage = newMessage;
            await context.SaveChangesAsync();
        }

    }
}
