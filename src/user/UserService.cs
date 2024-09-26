using PruebaDotnet.src.interfaces;
using PruebaDotnet.src.repository;
using PruebaDotnet.src.user.entity;

namespace PruebaDotnet.src.user
{
    public class UserService : IServices<UserEntity>
    {
        private readonly IRepository<UserEntity> _UserRepository;

        public UserService(IRepository<UserEntity> userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task<UserEntity> Add(UserEntity entity)
        {
            var user = new UserEntity
            {
                username = entity.username,
                password = entity.password,
                state = true
            };
            await _UserRepository.Add(user);
            return user;
        }



        public Task<IEnumerable<UserEntity>> Get()
        {
            return _UserRepository.Get();
        }
        public async Task<UserEntity> GetById(int id)
        {
            return await _UserRepository.GetOne(id);
        }

        public async Task<UserEntity> Update(int id, UserEntity entity)
        {
            return await _UserRepository.Update(id, entity);
        }

        public async Task Delete(int id)
        {
            await _UserRepository.Delete(id);
            return;
        }
    }
}