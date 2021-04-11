using EarlyBird.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;

namespace EarlyBird.BusinessLogic.Services.Interfaces
{
    public interface IReviewsService
    {
        IEnumerable<ViewReviewDto> GetReviewsForReceiver(Guid receiverId);
        ViewReviewDto GetById(int id);

        bool Delete(int id);

        ViewReviewDto Add(AddReviewDto addReviewDto);

        Guid GetSenderId(int reviewId);

        IEnumerable<ViewReviewDto> GetAll();

        public bool Update(int id, UpdateReviewDto updateReviewDto);

    }
}
