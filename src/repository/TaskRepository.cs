using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaDotnet.src.interfaces;
using PruebaDotnet.src.task.entity;

namespace PruebaDotnet.src.repository
{
    public class TaskRepository : IRepository<TaskEntity>
    {
        private readonly BdPruebaContext _context;

        public TaskRepository(BdPruebaContext context)
        {
            _context = context;
        }
        public async Task<TaskEntity> Add(TaskEntity entity)
        {
            var newTask = await _context.Tasks.AddAsync(entity);
            await Save();
            return entity;
        }

        public async Task<IEnumerable<TaskEntity>> Get() => await _context.Tasks.Where(u => u.state != 0).ToListAsync();

        public async Task<TaskEntity> GetOne(int id) => await _context.Tasks.Where(u => u.state != 0).FirstOrDefaultAsync(u => u.id == id);

        public async Task<TaskEntity> Update(int id, TaskEntity entity)
        {
            var tasks = await GetOne(id);
            tasks.title = entity.title;
            tasks.description = entity.description;
            tasks.expiration_date = entity.expiration_date;
            tasks.state = entity.state;
            await Save();
            return await GetOne(id);
        }

        public async Task Delete(int id)
        {
            var task = await GetOne(id);
            task.state = 0;
            await Save();
            return;
        }
        public async Task Save() => await _context.SaveChangesAsync();
    }
}