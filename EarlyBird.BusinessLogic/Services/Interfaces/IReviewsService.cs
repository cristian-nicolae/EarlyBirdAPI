using EarlyBird.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;

namespace EarlyBird.BusinessLogic.Services.Interfaces
{
    public interface IReviewsService
    {
        IEnumerable<ViewReviewDto> GetReviewsForReceiver();
        ViewReviewDto GetById(int id);

        bool Delete(int id);

        ViewReviewDto Add(AddReviewDto addReviewDto);


    }
}
