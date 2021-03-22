using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.BusinessLogic.Utils
{
    public static class Mapper
    {
        public static UserDto ToDto(this UserModel model)
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
