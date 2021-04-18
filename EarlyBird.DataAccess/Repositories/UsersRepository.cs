using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public bool Update(Guid id, UserEntity userEntity)
        {
            context.Update(userEntity);
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

        public double GetAverageRating(Guid id)
        {
            var x = context.Users.Include(x => x.ReviewsReceived).Where(x => x.Id == id).Select(x => x.ReviewsReceived).FirstOrDefault();
            if (x.Count == 0)
                return 0;
            return x.Average(x => x.Rating);
        }

        public UserEntity GetByUsername(string username)
        {
            return context.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}
