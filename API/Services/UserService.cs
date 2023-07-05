using API.Entities;
using API.Repositories;

namespace API.Services
{
    public class UserService: IUserService
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

        public async Task UpdateUserNameAsync(int userId, string userName)
        {
           await  _userRepository.UpdateUser(userId, userName);
        }

        public async Task<bool> UserAlreadyExist(string userName)
        {
            bool isExist = await _userRepository.AlreadyExist(userName);
            return isExist;
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            var user = await _userRepository.GetUserByName(userName);
            return user;
        }

        public async Task<User> GetUserNameWithPasswordAsync(string userName)
        {
            var user = await _userRepository.GetUserByNameWithPassword(userName);
            return user;
        }
        public async Task GetUserNameWithAllPasswordAsync(User user)
        {
            await _userRepository.GetAllPassword(user);
        }
    }
}
