using EarlyBird.BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace EarlyBird.BusinessLogic.Services
{
    public class ConnectedUsersService: IConnectedUsersService
    {
        private Dictionary<Guid, string> ConnectedUsers = new Dictionary<Guid, string>();
        
        public void Add(Guid userId, string connectionId)
        {
            ConnectedUsers.Add(userId, connectionId);
        }

        public void Remove(Guid userId)
        {
            ConnectedUsers.Remove(userId);
        }

        public string GetConnectionId(Guid userId)
        {
            if (!ConnectedUsers.ContainsKey(userId))
                return null;
            return ConnectedUsers.GetValueOrDefault(userId);
        }
    }
}
