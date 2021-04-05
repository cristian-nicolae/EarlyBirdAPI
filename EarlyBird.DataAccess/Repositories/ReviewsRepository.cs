using EarlyBird.DataAccess;
using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<ReviewEntity> GetReviewsForReceiver()
        {
            return context.Reviews.ToList();
        }

        public bool Update(int id, ReviewEntity reviewEntity)
        {
            var oldReview = GetById(id);
            if (oldReview == null)
                return false;
            oldReview.Title = reviewEntity.Title;
            oldReview.Rating = reviewEntity.Rating;
            oldReview.Description = reviewEntity.Description;
            return context.SaveChanges() > 0;
        }
    }
}
