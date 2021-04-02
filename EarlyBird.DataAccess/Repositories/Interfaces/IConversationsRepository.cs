using EarlyBird.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.DataAccess.Repositories.Interfaces
{
    public interface IConversationsRepository
    {
        ConversationEntity GetById(int id);
        IEnumerable<ConversationEntity> GetUserConversations(Guid userId);
        ConversationEntity Add(ConversationEntity conversationEntity);
        bool Delete(int id);
        bool Update(ConversationEntity conversationEntity);
    }
}
