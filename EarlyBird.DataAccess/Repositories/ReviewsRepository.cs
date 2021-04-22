using EarlyBird.DataAccess;
using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EarlyBird.API
{
    public class ReviewsRepository : IReviewsRepository
    {
        private readonly EarlyBirdContext context;

        public ReviewsRepository(EarlyBirdContext context)
        {
            this.context = context;
        }
        public ReviewEntity Add(ReviewEntity reviewEntity)
        {
            context.Reviews.Add(reviewEntity);
            context.SaveChanges();
            return reviewEntity;
        }

        public bool Delete(ReviewEntity reviewEntity)
        {
            context.Reviews.Remove(reviewEntity);
            return context.SaveChanges() > 0;
        }

        public IEnumerable<ReviewEntity> GetAll()
        {
            return context.Reviews.ToList();
        }

        public ReviewEntity GetById(int id)
        {
            return context.Reviews.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ReviewEntity> GetReviewsForReceiver(Guid receiverId)
        {
            return context.Reviews
                .Include(x => x.Sender)
                .Where(r => r.ReceiverId == receiverId)
                .ToList();
        }

        public bool Update(int id, ReviewEntity reviewEntity)
        {

            context.Update(reviewEntity);
            return context.SaveChanges() > 0;
        }
    }
}
