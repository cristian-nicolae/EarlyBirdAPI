using EarlyBird.API.Models;
using EarlyBird.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarlyBird.API.Utils
{
    public static class Mapper
    {
        public static RegisterUserDto ToRegisterUserDto(this RegisterRequest model)
        {
            return new RegisterUserDto
            {
                Username = model.Username,
                Password = model.Password,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Role = model.Role
            };
        }

        public static MessageDto ToMessageDto(this ChatMessage chatMessage, Guid senderId)
        {
            return new MessageDto
            {
                ConversationId = chatMessage.ConversationId,
                SenderId = senderId,
                Content = chatMessage.Message
            };
        }
    }
}
