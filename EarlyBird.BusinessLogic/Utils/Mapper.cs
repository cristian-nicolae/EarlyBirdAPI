using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.DataAccess.Entities;


namespace EarlyBird.BusinessLogic.Utils
{
    public static class Mapper
    {
        public static UserDto ToDto(this UserEntity entity)
        {
            return new UserDto
            {
                Id = entity.Id,
                Username = entity.Username,
                Role = entity.Role
            };
        }

        public static ViewUserDto ToViewUserDto(this UserEntity entity, double avgRating)
        {
            return new ViewUserDto
            {
                Id = entity.Id,
                Firstname = entity.Firstname,
                Lastname = entity.Lastname,
                Username = entity.Username,
                AvgRating = avgRating,
                Role = entity.Role
            };
        }

        public static ViewCategoryDto ToViewCategoryDto(this CategoryEntity entity)
        {
            return new ViewCategoryDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
        public static AddCategoryDto ToAddCategoryDto(this CategoryEntity entity)
        {
            return new AddCategoryDto
            {
                Name = entity.Name
            };
        }
        public static ViewReviewDto ToViewReviewDto(this ReviewEntity entity)
        {
            return new ViewReviewDto
            {
                Id = entity.Id,
                ReceiverId = entity.ReceiverId,
                SenderId = entity.SenderId,
                Title = entity.Title,
                Rating = entity.Rating,
                Description = entity.Description
            };
        }

        public static AddReviewDto ToAddReviewDto(this ReviewEntity entity)
        {
            return new AddReviewDto
            {
                Title = entity.Title,
                Rating = entity.Rating,
                Description = entity.Description
            };
        }

        public static ReviewEntity ToReviewEntity(this UpdateReviewDto updateDto)
        {
            return new ReviewEntity
            {
                Title = updateDto.Title,
                Rating = updateDto.Rating,
                Description = updateDto.Description
            };
        }
    }
}
