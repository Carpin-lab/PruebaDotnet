using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDotnet.src.interfaces;
using PruebaDotnet.src.task.dto;
using PruebaDotnet.src.task.entity;

namespace PruebaDotnet.src.task
{
    public class TaskService : IServices<TaskDto>
    {
        private readonly IRepository<TaskEntity> _TaskRepository;

        public TaskService(IRepository<TaskEntity> TaskRepository)
        {
            _TaskRepository = TaskRepository;
        }

        public async Task<TaskDto> Add(TaskDto entity)
        {
            var newTask = new TaskEntity
            {
                title = entity.title,
                description = entity.description,
                expiration_date = entity.expiration_date,
                state = entity.state == true ? 2 : 3
            };
            var result = await _TaskRepository.Add(newTask);

            return new TaskDto
            {
                title = result.title,
                description = result.description,
                expiration_date = result.expiration_date,
                state = result.state == 2 ? true : false
            };
        }


        public async Task<IEnumerable<TaskDto>> Get()
        {
            var result = await _TaskRepository.Get();
            Console.WriteLine(result);
            foreach (var item in result)
            {
                Console.WriteLine(item.title);
            }
            return result.Select(task => new TaskDto
            {
                title = task.title,
                description = task.description,
                expiration_date = task.expiration_date,
                state = task.state == 2 ? true : false
            });
        }

        public async Task<TaskDto> GetById(int id)
        {
            var result = await _TaskRepository.GetOne(id);
            return new TaskDto
            {
                title = result.title,
                description = result.description,
                expiration_date = result.expiration_date,
                state = result.state == 2 ? true : false
            };
        }

        public async Task<TaskDto> Update(int id, TaskDto entity)
        {
            var newTask = new TaskEntity
            {
                title = entity.title,
                description = entity.description,
                expiration_date = entity.expiration_date,
                state = entity.state == true ? 2 : 3
            };

            var result = await _TaskRepository.Update(id, newTask);
            return new TaskDto
            {
                title = result.title,
                description = result.description,
                expiration_date = result.expiration_date,
                state = result.state == 2 ? true : false
            };
        }

        public async Task Delete(int id)
        {
            await _TaskRepository.Delete(id);
            return;
        }
    }
}