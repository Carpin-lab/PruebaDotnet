using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDotnet.src.interfaces;
using PruebaDotnet.src.user.entity;

namespace PruebaDotnet.src.user
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase, IControllers<UserEntity>
    {
        private readonly IServices<UserEntity> _userService;

        public UserController(IServices<UserEntity> userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserEntity entity)
        {
            var newUser = await _userService.Add(entity);
            return newUser != null ? Ok(newUser) : BadRequest(); //FIXME: We need to return the object created
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var User = await _userService.GetById(id);
            if (User == null)
                return NotFound("User not found");
            return Ok(User);
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var Users = await _userService.Get();
            return Ok(Users);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserEntity entity)
        {
            var existingUser = await _userService.GetById(id);
            if (existingUser == null)
            {
                return NotFound("User not found");
            }
            var UserUpdate = await _userService.Update(id, entity);
            return Ok(UserUpdate);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingUser = await _userService.GetById(id);
            if (existingUser == null)
            {
                return NotFound("User not found");
            }
            await _userService.Delete(id);
            return Ok();
        }
    }
}