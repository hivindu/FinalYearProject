﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UCRDAUsers.API.Data.Interface;
using UCRDAUsers.API.Entities;
using UCRDAUsers.API.Repository.Interface;

namespace UCRDAUsers.API.Repository
{
    public class UCRDAUserRepository : IUCRDAUserRepository
    {
        private readonly IUCRDAUserContext _context;
        public UCRDAUserRepository(IUCRDAUserContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<UCRDAUser>> GetUsers()
        {
            return await _context.ucrdausers.Find(p => true).ToListAsync();
        }

        public async Task<UCRDAUser> GetUser(string id)
        {
            return await _context.ucrdausers.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<UCRDAUser> GetUserByCredentials(string nic, string password)
        {
            return await _context.ucrdausers.Find(p => p.NIC == nic && p.Password == password).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UCRDAUser>> GetWorkersByTypeAndArea(string area)
        {
            return await _context.ucrdausers.Find(p => p.Type == 1 && p.LocationArea == area && p.Work==1).ToListAsync();
        }

        public async Task<IEnumerable<UCRDAUser>> GetAllWorkersByTypeAndArea(string area, int work)
        {
            return await _context.ucrdausers.Find(p => p.LocationArea == area && p.Work == work).ToListAsync();
        }

        public async Task Create(UCRDAUser user)
        {
            await _context.ucrdausers.InsertOneAsync(user);
        }

        public async Task<bool> Update(UCRDAUser user)
        {
            var result = await _context.ucrdausers.ReplaceOneAsync(p=> p.Id == user.Id, replacement :user);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<UCRDAUser> filter = Builders<UCRDAUser>.Filter.Eq(p=>p.Id,id);

            DeleteResult deletedResult = await _context.ucrdausers.DeleteOneAsync(filter);

            return deletedResult.IsAcknowledged && deletedResult.DeletedCount > 0;

        }

        
    }
}
