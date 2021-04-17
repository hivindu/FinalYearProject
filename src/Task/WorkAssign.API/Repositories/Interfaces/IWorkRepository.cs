using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkAssign.API.Entities;

namespace WorkAssign.API.Repositories.Interfaces
{
    public interface IWorkRepository
    {
        Task<IEnumerable<Work>> GetTaskList();

        Task<Work> GetTask(string id);

        Task<IEnumerable<Work>> GetTaskListByUid(string userId);

        Task<IEnumerable<Work>> GetTaskByDate(DateTime date);

        Task<IEnumerable<Work>> GetTaskByArea(string area);

        Task Create(Work work);

        Task<bool> Update(Work work);

        Task<bool> Delete(string id);
    }
}
