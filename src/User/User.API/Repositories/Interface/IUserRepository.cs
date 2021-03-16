using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.Entities;

namespace User.API.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetUsers();

        Task<Users> GetUser(string id);

        Task<IEnumerable<Users>> GetUserByNic(string nic);

        Task<IEnumerable<Users>> GetUserByType(string type);

        Task Create(Users user);

        Task<bool> Update(Users user);

        Task<bool> Delete(string id);
    }
}
