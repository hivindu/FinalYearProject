using Approve.API.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Approve.API.Respository.Interfaces
{
    public interface IApproveRepository
    {
        Task<IEnumerable<Approval>> GetApproval();

        Task<Approval> GetApproval(string id);

        Task<IEnumerable<Approval>> GetApprovalByUserId(string uid);

        Task<IEnumerable<Approval>> GetApprovalbyIds(string uid, string iid);

        Task Create(Approval approval);

        Task<bool> Update(Approval approval);

        Task<bool> Delete(string id);
    }
}
