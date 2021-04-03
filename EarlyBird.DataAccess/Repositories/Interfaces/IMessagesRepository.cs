using EarlyBird.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.DataAccess.Repositories.Interfaces
{
    public interface IMessagesRepository
    {
        MessageEntity GetById(int id);
        IEnumerable<MessageEntity> GetConversationMessages(int conversationId);
        MessageEntity Add(MessageEntity messageEntity);
        bool Delete(MessageEntity messageEntity);
        bool Update(int id, MessageEntity messageEntity);
    }
}
