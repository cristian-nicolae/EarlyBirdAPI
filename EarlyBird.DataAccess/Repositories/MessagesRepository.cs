using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.DataAccess.Repositories
{
    public class MessagesRepository : IMessagesRepository
    {
        public MessageEntity Add(MessageEntity messageEntity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(MessageEntity messageEntity)
        {
            throw new NotImplementedException();
        }

        public MessageEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MessageEntity> GetConversationMessages(int conversationId)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, MessageEntity messageEntity)
        {
            throw new NotImplementedException();
        }
    }
}
