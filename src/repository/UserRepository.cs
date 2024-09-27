using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaDotnet.src.interfaces;
using PruebaDotnet.src.user.entity;

namespace PruebaDotnet.src.repository
{
    public class UserRepository : IRepository<UserEntity>
    {
        private readonly BdPruebaContext _context;

        public UserRepository(BdPruebaContext context)
        {
            _context = context;
        }
        public async Task<UserEntity> Add(UserEntity entity)
        {
            await _context.Users.AddAsync(entity);
            await Save();
            return entity;
        }


        public async Task<IEnumerable<UserEntity>> Get() => await _context.Users.Where(u => u.state == true).ToListAsync();

        public async Task<UserEntity> GetOne(int id) => await _context.Users.Where(u => u.state == true).FirstOrDefaultAsync(u => u.id == id);
        public async Task<UserEntity> GetByUsername(string username) => await _context.Users.Where(u => u.state == true).FirstOrDefaultAsync(u => u.username == username);

        public async Task<UserEntity> Update(int id, UserEntity entity)
        {
            var user = await GetOne(id);
            user.username = entity.username;
            user.password = entity.password;
            await Save();
            return await GetOne(id);
        }

        public async Task Delete(int id)
        {
            var user = await GetOne(id);
            user.state = false;
            await Save();
            return;
        }
        public async Task Save() => await _context.SaveChangesAsync();
    }
}