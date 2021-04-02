using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

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
            var userToBeDeleted = GetById(id);
            if (userToBeDeleted == null)
                throw new UserNotFoundException();
            return _users.Remove(userToBeDeleted);
        }

        public bool UpdateUser(UserEntity updatedUser)
        {
            throw new NotImplementedException();
        }

        [Serializable]
        private class UserNotFoundException : Exception
        {
            public UserNotFoundException()
            {
            }
            public UserNotFoundException(string message) : base(message)
            {
            }

        }
    }
}
