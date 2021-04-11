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
                ReceiverId = addReviewDto.ReceiverId,
                SenderId = addReviewDto.SenderId,
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
        public bool Update(int id, UpdateReviewDto updateReviewDto)
        {
            var reviewEntity = reviewsRepository.GetById(id);
            if (reviewEntity == null)
                throw new ReviewNotFoundException();
            reviewEntity.Title = updateReviewDto.Title ?? reviewEntity.Title;
            reviewEntity.Rating = updateReviewDto.Rating ==  0 ? reviewEntity.Rating : updateReviewDto.Rating;
            reviewEntity.Description = updateReviewDto.Description ?? reviewEntity.Description;
            return reviewsRepository.Update(id, reviewEntity);
        }

        public IEnumerable<ViewReviewDto> GetReviewsForReceiver(Guid receiverId)
        {
            return reviewsRepository.GetReviewsForReceiver(receiverId).Select(x => x.ToViewReviewDto());
        }

        public ViewReviewDto GetById(int id)
        {
            return reviewsRepository.GetById(id)?.ToViewReviewDto();
        }

        public Guid GetSenderId(int reviewId)
        {
            var review = reviewsRepository.GetById(reviewId);
            if (review == null)
                throw new ReviewNotFoundException();
            return review.SenderId;
        }

        public IEnumerable<ViewReviewDto> GetAll()
        {
            return reviewsRepository.GetAll().Select(x => x.ToViewReviewDto()).ToList();
        }

        [Serializable]
        public class ReviewNotFoundException : Exception
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
