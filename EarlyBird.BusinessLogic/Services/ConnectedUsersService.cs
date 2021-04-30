using EarlyBird.BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace EarlyBird.BusinessLogic.Services
{
    public class ConnectedUsersService: IConnectedUsersService
    {
        private Dictionary<Guid, List<string>> ConnectedUsers = new Dictionary<Guid, List<string>>();
        
        public void Add(Guid userId, string connectionId)
        {
            if (ConnectedUsers.ContainsKey(userId))
                ConnectedUsers.GetValueOrDefault(userId).Add(connectionId);
            else
                ConnectedUsers.Add(userId, new List<string> { connectionId });
        }

        public void Remove(Guid userId, string connectionId)
        {
            var connections = ConnectedUsers.GetValueOrDefault(userId);
            connections.Remove(connectionId);
            if (connections.Count == 0)
                ConnectedUsers.Remove(userId);
        }

        public List<string> GetConnectionIds(Guid userId)
        {
            if (!ConnectedUsers.ContainsKey(userId))
                return null;
            return ConnectedUsers.GetValueOrDefault(userId);
        }
    }
}
