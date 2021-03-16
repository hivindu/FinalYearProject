using Approve.API.Data.Interfaces;
using Approve.API.Entites;
using Approve.API.Respository.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Approve.API.Respository
{
    public class ApproveRepository : IApproveRepository
    {
        private readonly IApproveContext _context;

        public ApproveRepository(IApproveContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Approval>> GetApproval()
        {
            return await _context.approval.Find(p => true).ToListAsync();
        }

        public async Task<Approval> GetApproval(string id)
        {
            return await _context.approval.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Approval>> GetApprovalByUserId(string uid)
        {
            return await _context.approval.Find(p => p.UserId == uid).ToListAsync();
        }

        public async Task<IEnumerable<Approval>> GetApprovalbyIds(string uid, string iid)
        {
            return await _context.approval.Find(p => p.UserId == uid && p.IssueId == iid).ToListAsync();
        }

        public async Task Create(Approval approval)
        {
            await _context.approval.InsertOneAsync(approval);
        }

        public async Task<bool> Update(Approval approval)
        {
            var UpdateResult = await _context.approval.ReplaceOneAsync(filter: g => g.Id == approval.Id, replacement: approval);

            return UpdateResult.IsAcknowledged && UpdateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Approval> filter = Builders<Approval>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context.approval.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        
    }
}
