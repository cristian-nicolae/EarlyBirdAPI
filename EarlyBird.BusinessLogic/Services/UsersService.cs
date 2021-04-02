using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.BusinessLogic.Services.Interfaces;
using EarlyBird.BusinessLogic.Utils;
using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories;
using EarlyBird.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EarlyBird.BusinessLogic.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;
        private readonly ITokenService tokenService;

        public UsersService(
            IUsersRepository usersRepository,
            ITokenService tokenService)
        {
            this.usersRepository = usersRepository;
            this.tokenService = tokenService;

            if (this.usersRepository.GetType() == typeof(UsersRepositoryMock))
                SeedUsers();
        }
        public IEnumerable<ViewUserDto> GetAll()
        {
            return usersRepository.GetAllUsers().Select(x => x.ToViewUserDto());
        }

        public ViewUserDto GetById(Guid id)
        {
            return usersRepository.GetById(id).ToViewUserDto();
        }

        public ViewUserDto GetByUsername(string username)
        {
            return usersRepository.GetByUsername(username).ToViewUserDto();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public string Register(RegisterUserDto registerUserDto)
        {
            var existingUser = usersRepository.GetByUsername(registerUserDto.Username);
            if (existingUser != null)
                throw new UserAlreadyExistingException();

            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            var newUser = new UserEntity
            {
                Id = Guid.NewGuid(),
                Username = registerUserDto.Username,
                Salt = salt,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerUserDto.Password + salt),
                Role = registerUserDto.Role
            };
            newUser = usersRepository.Add(newUser);
            return tokenService.GenerateAccessToken(newUser.ToDto());

        }
        public string Authenticate(string username, string password)
        {
            var user = usersRepository.GetByUsername(username);
            if (user == null) return null;

            bool verified = BCrypt.Net.BCrypt.Verify(password + user.Salt, user.PasswordHash);

            return verified ? tokenService.GenerateAccessToken(user.ToDto()) : null;
        }


        #region private
        private void SeedUsers()
        {
            var salt1 = BCrypt.Net.BCrypt.GenerateSalt();
            usersRepository.Add(new DataAccess.Entities.UserEntity
            {
                Id = Guid.NewGuid(),
                Username = "admin",
                Salt = salt1,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin" + salt1),
                Role = Roles.Admin
            });

            var salt2 = BCrypt.Net.BCrypt.GenerateSalt();
            usersRepository.Add(new DataAccess.Entities.UserEntity
            {
                Id = Guid.NewGuid(),
                Username = "worker",
                Salt = salt2,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("worker" + salt2),
                Role = Roles.Worker
            });

            var salt3 = BCrypt.Net.BCrypt.GenerateSalt();
            usersRepository.Add(new DataAccess.Entities.UserEntity
            {
                Id = Guid.NewGuid(),
                Username = "publisher",
                Salt = salt3,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("publisher" + salt3),
                Role = Roles.Publisher
            });


        }

       

        [System.Serializable]
        private class UserAlreadyExistingException : System.Exception
        {
            public UserAlreadyExistingException()
            {
            }

            public UserAlreadyExistingException(string message) : base(message)
            {
            }

        }

        #endregion
    }
}