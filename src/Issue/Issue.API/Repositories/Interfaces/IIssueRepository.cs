using Issue.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Issue.API.Repositories.Interfaces
{
    public interface IIssueRepository
    {
        Task<IEnumerable<Issues>> GetIssues();

        Task<Issues> GetIssue(string id);

        Task<IEnumerable<Issues>> GetIssueByDate(string date);

        Task<IEnumerable<Issues>> GetIssueByRoad(string road);

        Task<IEnumerable<Issues>> GetIssuebyType(int type, string area);

        Task<IEnumerable<Issues>> GetIssueByAdminArea(string area);

        Task<IEnumerable<Issues>> GetIssueByUserId(string Uid);

        Task<IEnumerable<Issues>> GetApprovedIssuesByAdminArea(string area);

        Task<IEnumerable<Issues>> GetAssignedRDAIssues(string area);

        Task Create(Issues issue);

        Task<bool> Update(Issues issue);

        Task<bool> Delete(string id);
    }
}
