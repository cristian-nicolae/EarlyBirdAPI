
using EarlyBird.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;

namespace EarlyBird.BusinessLogic.Services.Interfaces
{
    public interface IUsersService
    {
        IEnumerable<ViewUserDto> GetAll();
        ViewUserDto GetById(Guid id);
        ViewUserDto GetByUsername();
        bool Delete(Guid id);
        string Register(RegisterUserDto registerUserDto);
        string Authenticate(string username, string password);

    }
}
