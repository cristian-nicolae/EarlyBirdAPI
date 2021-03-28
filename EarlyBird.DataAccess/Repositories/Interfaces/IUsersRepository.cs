using EarlyBird.DataAccess.Models;
using System;

namespace EarlyBird.DataAccess.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        UserModel GetById(Guid id);
        UserModel GetByUsername(string username);

        UserModel Add(UserModel user);
    }
}
