using PruebaDotnet.src.interfaces;
using PruebaDotnet.src.user.dto;
using PruebaDotnet.src.user.entity;

namespace PruebaDotnet.src.user
{
    public class UserService : IServices<UserDto>
    {
        private readonly IRepository<UserEntity> _UserRepository;

        public UserService(IRepository<UserEntity> userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task<UserDto> Add(UserDto entity)
        {
            var user = new UserEntity
            {
                username = entity.username,
                password = entity.password,
                state = true
            };
            await _UserRepository.Add(user);
            return new UserDto
            {
                id = user.id,
                username = user.username,
                password = user.password
            };
        }



        public async Task<IEnumerable<UserDto>> Get()
        {
            var users = await _UserRepository.Get();
            return users.Select(task => new UserDto
            {
                id = task.id,
                username = task.username,
                password = task.password
            });
        }
        public async Task<UserDto> GetById(int id)
        {
            var user = await _UserRepository.GetOne(id);
            if (user == null)
            {
                return null;
            }
            return new UserDto
            {
                id = user.id,
                username = user.username,
                password = user.password
            };
        }

        public async Task<UserDto> Update(int id, UserDto entity)
        {
            var user_update = new UserEntity
            {
                username = entity.username,
                password = entity.password
            };
            var result = await _UserRepository.Update(id, user_update);
            return new UserDto
            {
                id = result.id,
                username = result.username,
                password = result.password
            };
        }

        public async Task Delete(int id)
        {
            await _UserRepository.Delete(id);
            return;
        }
    }
}