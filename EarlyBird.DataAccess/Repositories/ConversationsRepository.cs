using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.DataAccess.Repositories
{
    public class ConversationsRepository : IConversationsRepository
    {
        public ConversationEntity Add(ConversationEntity conversationEntity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ConversationEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConversationEntity> GetUserConversations(Guid userId)
        {
            throw new NotImplementedException();
        }

        public bool Update(ConversationEntity conversationEntity)
        {
            throw new NotImplementedException();
        }
    }
}
