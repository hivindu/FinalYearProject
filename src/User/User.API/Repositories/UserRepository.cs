using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.Data.Interface;
using User.API.Entities;

namespace User.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserContext _context;

        public UserRepository(IUserContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            return await _context.users.Find(p => true).ToListAsync();
        }

        public async Task<Users> GetUser(string id)
        {
            return await _context.users.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Users>> GetUserByNic(string nic)
        {
            return await _context.users.Find<Users>(x => x.NIC == nic).ToListAsync();
        }

        public async Task<IEnumerable<Users>> GetUserByType(string type)
        {
            return await _context.users.Find<Users>(x => x.Type == type).ToListAsync();
        }

        public async Task Create(Users user)
        {
            await _context.users.InsertOneAsync(user);
        }

        public  async Task<bool> Update(Users user)
        {
            var UpdateResult = await _context.users.ReplaceOneAsync(filter: g => g.Id == user.Id, replacement: user);

            return UpdateResult.IsAcknowledged && UpdateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Users> filter = Builders<Users>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context.users.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

    }
}
