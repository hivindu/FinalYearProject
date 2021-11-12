using System.Collections.Generic;
using System.Threading.Tasks;
using UCRDAUsers.API.Entities;

namespace UCRDAUsers.API.Repository.Interface
{
    public interface IUCRDAUserRepository
    {
        Task<IEnumerable<UCRDAUser>> GetUsers();

        Task<UCRDAUser> GetUser(string id);

        Task<UCRDAUser> GetUserByCredentials(string nic,string password);

        Task<IEnumerable<UCRDAUser>> GetWorkersByTypeAndArea(string area);

        Task<IEnumerable<UCRDAUser>> GetAllWorkersByTypeAndArea(string area, int work);

        Task Create(UCRDAUser user);

        Task<bool> Update(UCRDAUser user);

        Task<bool> Delete(string id);
    }
}
