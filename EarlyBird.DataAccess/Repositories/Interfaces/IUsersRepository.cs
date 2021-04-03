﻿using EarlyBird.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace EarlyBird.DataAccess.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        UserEntity GetById(Guid id);
        UserEntity GetByUsername(string username);
        UserEntity Add(UserEntity user);
        IEnumerable<UserEntity> GetAll();
        bool Delete(UserEntity user);


    }
}