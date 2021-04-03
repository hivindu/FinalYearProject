using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCRDAUsers.API.Entities;
using UCRDAUsers.API.Repository.Interface;

namespace UCRDAUsers.API.Repository
{
    public class UCRDAUserRepository : IUCRDAUserRepository
    {
        public Task<IEnumerable<UCRDAUser>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<UCRDAUser> GetUSer(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UCRDAUser> GetUserByCredentials(string nic, string password)
        {
            throw new NotImplementedException();
        }

        public Task Create(UCRDAUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UCRDAUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
