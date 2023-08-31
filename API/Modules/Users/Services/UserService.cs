using API.Modules.User.Repositories;
using API.Shared.Entities;
using SharedUser = API.Shared.Entities;

namespace API.Modules.User.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task CreateUserAsync(SharedUser.User user)
        {
            await _userRepository.Create(user);
        }



        public async Task<SharedUser.User> GetUserByIdAsync(string id)
        {
            var user = await _userRepository.GetById(id);
            if (user is null)
            {
                return null;
            }
            return user;
        }

        public Task UpdateUserAsync(SharedUser.User user)
        {
            return _userRepository.Update(user);
        }

        public Task DeleteUserAsync(SharedUser.User user)
        {
            return _userRepository.Delete(user);
        }

        public async Task UpdateUserNameAsync(string userId, string userName)
        {
            await _userRepository.UpdateUser(userId, userName);
        }

        public async Task<bool> UserAlreadyExist(string userName)
        {
            bool isExist = await _userRepository.AlreadyExist(userName);
            return isExist;
        }

        public async Task<SharedUser.User> GetUserByUserNameAsync(string userName)
        {
            var user = await _userRepository.GetUserByName(userName);
            return user;
        }

        public async Task<SharedUser.User> GetUserNameWithPasswordAsync(string userName)
        {
            var user = await _userRepository.GetUserByNameWithPassword(userName);
            return user;
        }
        public async Task GetUserNameWithAllPasswordAsync(SharedUser.User user)
        {
            await _userRepository.GetAllPassword(user);
        }

    }
}
