using EarlyBird.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.DataAccess.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        UserModel GetById(Guid id);
        UserModel GetByUsername(string username);

        UserModel Add(UserModel user);
    }
}
