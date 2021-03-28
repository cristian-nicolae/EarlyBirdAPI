using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.DataAccess.Entities;


namespace EarlyBird.BusinessLogic.Utils
{
    public static class Mapper
    {
        public static UserDto ToDto(this UserEntity model)
        {
            return new UserDto
            {
                Id = model.Id,
                Username = model.Username,
                Role = model.Role
            };
        }
    }
}
