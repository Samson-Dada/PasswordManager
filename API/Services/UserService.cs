using API.Models;
using API.Repositories;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.Create(user);
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            var users = await _userRepository.GetAll();
            return users;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user is null)
            {
                return null;
            }
            return user;
        }
        public Task UpdateUserAsync(User user)
        {
            return _userRepository.Update(user);
        }
        public Task DeleteUserAsync(User user)
        {
            return _userRepository.Delete(user);
        }
    }
}
