using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkAssign.API.Data.Interface;
using WorkAssign.API.Entities;
using WorkAssign.API.Repositories.Interfaces;

namespace WorkAssign.API.Repositories
{
    public class WorkRepository : IWorkRepository
    {
        private readonly IWorkContext _context;
        public WorkRepository(IWorkContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Work>> GetTaskList()
        {
            return await _context.task.Find<Work>(p=>true).ToListAsync();
        }

        public async Task<Work> GetTask(string id)
        {
            return await _context.task.Find<Work>(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Work>> GetTaskByDate(DateTime date)
        {
            return await _context.task.Find<Work>(p => p.AssignedDate == date).ToListAsync();
        }

        public async Task<IEnumerable<Work>> GetTaskListByUid(string userId)
        {
            return await _context.task.Find<Work>(p => p.UserUd == userId).ToListAsync();
        }

        public async Task<IEnumerable<Work>> GetTaskByArea(string area)
        {
            return await _context.task.Find<Work>(p => p.Area==area).ToListAsync();
        }

        public async Task Create(Work work)
        {
            await _context.task.InsertOneAsync(work);
        }

        public async Task<bool> Update(Work work)
        {
            var UpdateResult = await _context.task.ReplaceOneAsync(filter: g => g.Id == work.Id, replacement: work);

            return UpdateResult.IsAcknowledged && UpdateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Work> filter = Builders<Work>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context.task.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        
    }
}
