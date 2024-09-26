using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDotnet.src.interfaces;
using PruebaDotnet.src.task.dto;
using PruebaDotnet.src.task.entity;

namespace PruebaDotnet.src.task
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase, IControllers<TaskDto>
    {

        private readonly IServices<TaskDto> _taskService;

        public TaskController(IServices<TaskDto> taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(TaskDto entity)
        {
            var result = await _taskService.Add(entity);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _taskService.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = _taskService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskDto entity)
        {
            var task = await _taskService.GetById(id);
            if (task == null)
            {
                return NotFound();
            }

            var result = await _taskService.Update(id, entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskService.Delete(id);
            return Ok();
        }
    }
}