﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCRDAUsers.API.Entities;

namespace UCRDAUsers.API.Repository.Interface
{
    public interface IUCRDAUserRepository
    {
        Task<IEnumerable<UCRDAUser>> GetUsers();

        Task<UCRDAUser> GetUser(string id);

        Task<UCRDAUser> GetUserByCredentials(string nic,string password);

        Task Create(UCRDAUser user);

        Task<bool> Update(UCRDAUser user);

        Task<bool> Delete(string id);
    }
}
