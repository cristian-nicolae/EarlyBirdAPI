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
                Firstname = entity.Firstname,
                Lastname = entity.Lastname,
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
        public static ViewReviewDto ToViewReviewDto(this ReviewEntity entity, double avg = 0)
        {
            return new ViewReviewDto
            {
                Id = entity.Id,
                ReceiverId = entity.ReceiverId,
                SenderId = entity.SenderId,
                Title = entity.Title,
                Rating = entity.Rating,
                Description = entity.Description,
                Sender = entity.Sender?.ToViewUserDto(avg)
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

        public static ConversationViewDto ToConversationViewDto(this ConversationEntity conversationEntity)
        {
            return new ConversationViewDto
            {
                Id = conversationEntity.Id,
                NewMessage = conversationEntity.NewMessage,
                FirstId = conversationEntity.FirstId,
                SecondId = conversationEntity.SecondId
            };
        }

        public static ConversationEntity ToConversationEntity(this ConversationDto conversationDto)
        {
            return new ConversationEntity
            {
                NewMessage = false,
                Id = default,
                FirstId = conversationDto.FirstId,
                SecondId = conversationDto.SecondId,
            };
        }

        public static MessageEntity ToMessageEntity(this MessageDto messageDto)
        {
            return new MessageEntity
            {
                Id = default,
                ConversationId = messageDto.ConversationId,
                SenderId = messageDto.SenderId,
                Content = messageDto.Content
            };
        }

        public static ViewMessageDto ToViewMessageDto(this MessageEntity messageEntity)
        {
            return new ViewMessageDto
            {
                Id = messageEntity.Id,
                SenderId = messageEntity.SenderId,
                Content = messageEntity.Content,
                ConversationId = messageEntity.ConversationId
            };
        }

    }
}
