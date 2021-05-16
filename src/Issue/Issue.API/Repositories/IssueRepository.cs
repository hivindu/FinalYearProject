using Issue.API.Data.Interfaces;
using Issue.API.Entities;
using Issue.API.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Issue.API.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private readonly IIssueContext _context;

        public IssueRepository(IIssueContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<IEnumerable<Issues>> GetIssues()
        {
            return await _context.issues.Find(p => true).ToListAsync();
        }

        public async Task<Issues> GetIssue(string id)
        {
            return await _context.issues.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Issues>> GetIssueByAdminArea(string area)
        {
            return await _context.issues.Find(p => p.AdminArea == area).ToListAsync();
        }

        public async Task<IEnumerable<Issues>> GetIssueByDate(string date)
        {
            return await _context.issues.Find(p => p.Date == date).ToListAsync();
        }

        public async Task<IEnumerable<Issues>> GetIssueByRoad(string road)
        {
            return await _context.issues.Find(p => p.RoadType == road).ToListAsync();
        }

        public async Task<IEnumerable<Issues>> GetIssuebyType(int type,string area)
        {
            return await _context.issues.Find<Issues>(p=> p.IssueType == type && p.AdminArea == area).ToListAsync();
        }

        public async Task<IEnumerable<Issues>> GetApprovedIssuesByAdminArea(string area)
        {
            return await _context.issues.Find<Issues>(p => p.Status == "Approved" &&  p.AdminArea == area).ToListAsync();
        }

        public async Task<IEnumerable<Issues>> GetAssignedRDAIssues(string area)
        {
            return await _context.issues.Find<Issues>(p => p.Status == "Assigned" && p.AdminArea == area ).ToListAsync();
        }

        public async Task<IEnumerable<Issues>> GetIssueByUserId(string Uid)
        {
            return await _context.issues.Find(p => p.UID == Uid).ToListAsync(); ;
        }


        public async Task Create(Issues issue)
        {
             await _context.issues.InsertOneAsync(issue);
        }

        public async Task<bool> Update(Issues issue)
        {
            var UpdateResult = await _context.issues.ReplaceOneAsync(filter: g => g.Id == issue.Id, replacement: issue);

            return UpdateResult.IsAcknowledged && UpdateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {

            FilterDefinition<Issues> filter = Builders<Issues>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context.issues.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        
    }
}
