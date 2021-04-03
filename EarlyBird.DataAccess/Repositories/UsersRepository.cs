using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly EarlyBirdContext context;

        public UsersRepository(EarlyBirdContext context)
        {
            this.context = context;
        }
        public UserEntity Add(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public UserEntity GetByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
