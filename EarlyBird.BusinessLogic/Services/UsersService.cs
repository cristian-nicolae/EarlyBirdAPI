using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.BusinessLogic.Services.Interfaces;
using EarlyBird.BusinessLogic.Utils;
using EarlyBird.DataAccess.Entities;
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

        }
        public IEnumerable<ViewUserDto> GetAll()
        {
            return usersRepository.GetAll().Select(x => x.ToViewUserDto());
        }

        public ViewUserDto GetById(Guid id)
        {
            return usersRepository.GetById(id)?.ToViewUserDto();
        }

        public ViewUserDto GetByUsername(string username)
        {
            return usersRepository.GetByUsername(username)?.ToViewUserDto();
        }

        public bool Delete(Guid id)
        {
            var user = usersRepository.GetById(id);
            if (user == null)
                throw new UserNotFoundException();
            return usersRepository.Delete(user);
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
                Firstname = registerUserDto.Firstname,
                Lastname = registerUserDto.Lastname,
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

        public bool UserExists(Guid userId)
        {
            return usersRepository.GetById(userId) != null;
        }


        #region exceptions       

        [System.Serializable]
        public class UserAlreadyExistingException : System.Exception
        {
            public UserAlreadyExistingException()
            {
            }

            public UserAlreadyExistingException(string message) : base(message)
            {
            }

        }

        [Serializable]
        public class UserNotFoundException : Exception
        {
            public UserNotFoundException()
            {
            }

            public UserNotFoundException(string message) : base(message)
            {
            }
        }

        #endregion
    }
}