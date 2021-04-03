using EarlyBird.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.DataAccess.Repositories.Interfaces
{
    public interface IReviewsRepository
    {
        ReviewEntity GetById(int id);
        IEnumerable<ReviewEntity> GetAll();
        IEnumerable<ReviewEntity> GetReviewsForReceiver(Guid receiverId);
        ReviewEntity Add(ReviewEntity reviewEntity);
        bool Delete(ReviewEntity reviewEntity);
        bool Update(int id, ReviewEntity reviewEntity);
    }
}
