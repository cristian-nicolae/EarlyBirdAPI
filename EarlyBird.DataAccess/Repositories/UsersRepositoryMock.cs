using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EarlyBird.DataAccess.Repositories
{
    public class UsersRepositoryMock : IUsersRepository
    {
        private List<UserEntity> _users = new List<UserEntity>();

        public UserEntity GetById(Guid id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public UserEntity GetByUsername(string username)
        {
            return _users.FirstOrDefault(x => x.Username == username);
        }
        public UserEntity Add(UserEntity user)
        {
            user.Id = Guid.NewGuid();
            _users.Add(user);
            return user;
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            return _users;
        }

        public bool DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(UserEntity updatedUser)
        {
            throw new NotImplementedException();
        }
    }
}
