using API.Modules.User.Repositories;
using API.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.AccessControl;
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

        //
        public async Task<IdentityUser> GetUserByIdAsync(string id)
        {
           IdentityUser user = await _userRepository.GetUserById(id);
            return user;
        }
        //
        public async Task<IdentityResult> DeleteUserAsync(IdentityUser user)
        {
            IdentityResult userToDelete = await _userRepository.DeleteUser(user);
            return userToDelete;
        }


        //
        public async Task<IdentityResult> UpdateUserAsync(SharedUser.User user)
        {
            IdentityResult userToUpdate = await _userRepository.UpdateUser(user);
            return userToUpdate;
        }

        //
        public async Task<bool> IsUsernameAlreadyExists(string userName)
        {
            bool userExist = await _userRepository.IsAlreadyExists(userName);
            return userExist;
        }


        //public async Task<IdentityResult> UpdateUsername(IdentityUser user)
        //{
        //    var updateUsername = await _userRepository.UpdateUsername(user);
        //    return updateUsername;
        //}

        public async Task<SharedUser.User> GetById(string id)
        {
            var user = await _userRepository.GetById(id);
            return user;
        }


        public async Task<SharedUser.User> GetUserByUserNameAsync(string userName)
        {
            var user = await _userRepository.GetUserByName(userName);
            return user;
        }
    }
}
