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
            var existingUser = GetByUsername(user.Username);
            if (existingUser != null)
                throw new UserAlreadyExistsException();
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

        public bool UpdateUser(Guid id, UserEntity updatedUser)
        {
            var userToBeUpdated = GetById(id);
            if (userToBeUpdated == null)
                throw new UserNotFoundException();
            userToBeUpdated.Username = updatedUser.Username ?? userToBeUpdated.Username;
            userToBeUpdated.PasswordHash = updatedUser.PasswordHash ?? userToBeUpdated.PasswordHash;
            userToBeUpdated.Salt = updatedUser.Salt ?? userToBeUpdated.Salt;
            userToBeUpdated.Role = updatedUser.Role ?? userToBeUpdated.Role;
            return true;
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

        [Serializable]
        private class UserAlreadyExistsException : Exception
        {
            public UserAlreadyExistsException()
            {
            }
            public UserAlreadyExistsException(string message) : base(message)
            {
            }

        }
    }
}
