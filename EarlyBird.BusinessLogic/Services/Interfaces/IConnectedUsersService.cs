using System;

namespace EarlyBird.BusinessLogic.Services.Interfaces
{
    interface IConnectedUsersService
    {
        public void Add(Guid userId, string connectionId);
        public void Remove(Guid userId);
        public string GetConnectionId(Guid userId);
    }
}
