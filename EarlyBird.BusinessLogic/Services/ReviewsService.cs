using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.BusinessLogic.Services.Interfaces;
using EarlyBird.BusinessLogic.Utils;
using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace EarlyBird.BusinessLogic.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly IReviewsRepository reviewsRepository;

        public ReviewsService(IReviewsRepository reviewsRepository)
        {
            this.reviewsRepository = reviewsRepository;
        }
  
        public ViewReviewDto Add(AddReviewDto addReviewDto)
        {
            ReviewEntity reviewEntity = new ReviewEntity
            {
                Title = addReviewDto.Title,
                Rating = addReviewDto.Rating,
                Description = addReviewDto.Description
            };
            reviewsRepository.Add(reviewEntity);
            return reviewEntity.ToViewReviewDto();
        }

        public bool Delete(int id)
        {
            ReviewEntity reviewEntity = reviewsRepository.GetById(id);
            if (reviewEntity == null)
                throw new ReviewNotFoundException();
            return reviewsRepository.Delete(reviewEntity);
        }

        public IEnumerable<ViewReviewDto> GetReviewsForReceiver()
        {
            return reviewsRepository.GetReviewsForReceiver().Select(x => x.ToViewReviewDto());
        }

        public ViewReviewDto GetById(int id)
        {
            return reviewsRepository.GetById(id).ToViewReviewDto();
        }

        [Serializable]
        private class ReviewNotFoundException : Exception
        {
            public ReviewNotFoundException()
            {
            }

            public ReviewNotFoundException(string message) : base(message)
            {
            }

            public ReviewNotFoundException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected ReviewNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
