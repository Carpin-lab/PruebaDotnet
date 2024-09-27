using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaDotnet.src.interfaces;
using PruebaDotnet.src.task.dto;
using PruebaDotnet.src.task.entity;
using PruebaDotnet.src.user.dto;

namespace PruebaDotnet.src.task
{

    [Authorize]
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
        public async Task<IActionResult> Add([FromBody] TaskDto entity)
        {
            if (entity.expiration_date == null || entity.title == null || entity.description == null || entity.state == null || entity.user_id == 0)
            {
                return BadRequest("Faltan datos");
            }
            try
            {
                var result = await _taskService.Add(entity);
                return Ok(result);
            }
            catch
            {
                return BadRequest("Error al insertar la tarea, porfavor verifique los datos del usuario");
            }

        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _taskService.GetById(id);
            if (result == null)
            {
                return NotFound("Task not found");
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _taskService.Get();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaskDto entity)
        {
            var task = await _taskService.GetById(id);
            if (task == null)
            {
                return NotFound("Task not found");
            }

            var result = await _taskService.Update(id, entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _taskService.GetById(id);
            if (task == null)
            {
                return NotFound("Task not found");
            }
            await _taskService.Delete(id);
            return Ok();
        }
    }
}