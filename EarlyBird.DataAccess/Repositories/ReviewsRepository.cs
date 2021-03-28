using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarlyBird.API
{
    public class ReviewsRepository : IReviewsRepository
    {
        public ReviewEntity Add(ReviewEntity reviewEntity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReviewEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public ReviewEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReviewEntity> GetReviewsForReceiver(Guid receiverId)
        {
            throw new NotImplementedException();
        }

        public bool Update(ReviewEntity reviewEntity)
        {
            throw new NotImplementedException();
        }
    }
}
