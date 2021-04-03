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

        public static ViewUserDto ToViewUserDto(this UserEntity entity)
        {
            return new ViewUserDto
            {
                Id = entity.Id,
                Username = entity.Username,
                Role = entity.Role
            };
        }
    }
}
