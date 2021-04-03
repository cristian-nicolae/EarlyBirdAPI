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
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public bool Delete(UserEntity user)
        {
            context.Users.Remove(user);
            return context.SaveChanges() > 0;
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return context.Users.ToList();
        }

        public UserEntity GetById(Guid id)
        {
            return context.Users.FirstOrDefault(x => x.Id == id);
        }

        public UserEntity GetByUsername(string username)
        {
            return context.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}
