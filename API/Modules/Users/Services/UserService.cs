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


        /* NEW METHOD FUNCTIONALITY*/

        //public async Task<IdentityResult> CreateUserAsyncs(SharedUser.User user, string password)
        //{
        //    IdentityResult newUser = await _userRepository.CreateUser(user, password);
        //    return newUser;

        //}

        public async Task<IdentityUser> GetUserByIdAsync(string id)
        {
           IdentityUser user = await _userRepository.GetUserById(id);
            return user;
        }

        //public async Task<IdentityResult> DeleteUserAsyncs(SharedUser.User user)
        //{
        //    IdentityResult userToDelete = await _userRepository.DeleteUser(user);
        //    return userToDelete;
        //}

        public async Task<IdentityResult> DeleteUserAsync(IdentityUser user)
        {
            IdentityResult userToDelete = await _userRepository.DeleteUser(user);
            return userToDelete;
        }


        //public async Task<IdentityResult> DeleteUserAsync(IdentityUser user)
        //{
        //    return await _userRepository.DeleteUserAsync(user);
        //}
        public async Task<IdentityResult> UpdateUserAsync(SharedUser.User user)
        {
            IdentityResult userToUpdate = await _userRepository.UpdateUser(user);
            return userToUpdate;
        }
        public async Task<bool> IsUsernameAlreadyExists(string userName)
        {
            bool userExist = await _userRepository.IsAlreadyExists(userName);
            return userExist;
        }





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


        /* OLD METHOD FUNCTIONALITY*/
        //public async Task CreateUserAsync(SharedUser.User user)
        //{
        //    await _userRepository.Create(user);
        //}



        //public async Task<SharedUser.User> GetUserByIdAsync(string id)
        //{
        //    var user = await _userRepository.GetById(id);
        //    if (user is null)
        //    {
        //        return null;
        //    }
        //    return user;
        //}

        //public Task UpdateUserAsync(SharedUser.User user)
        //{
        //    return _userRepository.Update(user);
        //}

        //public Task DeleteUserAsync(SharedUser.User user)
        //{
        //    return _userRepository.Delete(user);
        //}

        //public async Task UpdateUserNameAsync(string userId, string userName)
        //{
        //    await _userRepository.UpdateUser(userId, userName);
        //}




        //public async Task<bool> UserAlreadyExist(string userName)
        //{
        //    bool isExist = await _userRepository.AlreadyExist(userName);
        //    return isExist;
        //}

        //public async Task<SharedUser.User> GetUserByUserNameAsync(string userName)
        //{
        //    var user = await _userRepository.GetUserByName(userName);
        //    return user;
        //}

        //public async Task<SharedUser.User> GetUserNameWithPasswordAsync(string userName)
        //{
        //    var user = await _userRepository.GetUserByNameWithPassword(userName);
        //    return user;
        //}

        //public async Task GetUserNameWithAllPasswordAsync(SharedUser.User user)
        //{
        //    await _userRepository.GetAllPassword(user);
        //}

        //TODO:: Remove later

        //public async Task<IEnumerable<SharedUser.User>> GetAllUsersAsync()
        //{
        //    return await _userRepository.GetAllUsers();
        //}
    }
}
