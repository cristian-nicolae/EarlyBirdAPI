using EarlyBird.BusinessLogic.Services.Interfaces;
using EarlyBird.BusinessLogic.Utils;
using EarlyBird.DataAccess.Repositories;
using EarlyBird.DataAccess.Repositories.Interfaces;

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



        public string Authenticate(string username, string password)
        {
            var user = usersRepository.GetByUsername(username);
            if (user == null) return null;

            bool verified = BCrypt.Net.BCrypt.Verify(password + user.Salt, user.PasswordHash);

            return verified ? tokenService.GenerateAccessToken(user.ToDto()) : null;
        }


        #region private methods
        private void SeedUsers()
        {
            var salt1 = BCrypt.Net.BCrypt.GenerateSalt();
            usersRepository.Add(new DataAccess.Models.UserModel
            {
                Username = "admin",
                Salt = salt1,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin" + salt1),
                Role = Constants.Roles.Admin
            });

            var salt2 = BCrypt.Net.BCrypt.GenerateSalt();
            usersRepository.Add(new DataAccess.Models.UserModel
            {
                Username = "worker",
                Salt = salt2,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("worker" + salt2),
                Role = Constants.Roles.Worker
            });

            var salt3 = BCrypt.Net.BCrypt.GenerateSalt();
            usersRepository.Add(new DataAccess.Models.UserModel
            {
                Username = "publisher",
                Salt = salt3,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("publisher" + salt3),
                Role = Constants.Roles.Publisher
            });


        }

        #endregion
    }
}