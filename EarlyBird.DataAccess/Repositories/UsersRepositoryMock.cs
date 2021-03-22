using EarlyBird.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.DataAccess.Repositories
{
    public class UsersRepositoryMock : IUsersRepository
    {
        private List<UserModel> _users = new List<UserModel>();

        public UserModel GetById(Guid id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public UserModel GetByUsername(string username)
        {
            return _users.FirstOrDefault(x => x.Username == username);
        }
        public UserModel Add(UserModel user)
        {
            user.Id = Guid.NewGuid();
            _users.Add(user);
            return user;
        }
    }
}
