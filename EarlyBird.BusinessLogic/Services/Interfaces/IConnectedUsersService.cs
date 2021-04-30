using System;
using System.Collections.Generic;

namespace EarlyBird.BusinessLogic.Services.Interfaces
{
    public interface IConnectedUsersService
    {
        public void Add(Guid userId, string connectionId);
        public void Remove(Guid userId, string connectionId);
        public List<string> GetConnectionIds(Guid userId);
    }
}
