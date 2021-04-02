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
            _users.Add(user);
            return user;
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            return _users;
        }

        public bool DeleteUser(UserEntity user)
        {
            return _users.Remove(user);
        }

        public bool UpdateUser(Guid id, UserEntity updatedUser)
        {
            var userToBeUpdated = GetById(id);
            if (userToBeUpdated == null)
                return false;
            userToBeUpdated.Username = updatedUser.Username ?? userToBeUpdated.Username;
            userToBeUpdated.PasswordHash = updatedUser.PasswordHash ?? userToBeUpdated.PasswordHash;
            userToBeUpdated.Salt = updatedUser.Salt ?? userToBeUpdated.Salt;
            userToBeUpdated.Role = updatedUser.Role ?? userToBeUpdated.Role;
            return true;
        }
    }
}
