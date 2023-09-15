using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedUser = API.Shared.Entities;

namespace API.Modules.User.Repositories
{
    public interface IUserRepository
    {
        /* NEW METHOD FUNCTIONALITY*/

        Task<IdentityResult> CreateUser(SharedUser.User user, string password);
        Task<IdentityUser> GetUserById(string id);
        Task<IdentityResult> DeleteUser(SharedUser.User user);
        Task<IdentityResult> DeleteUser(IdentityUser user);
        Task<IdentityResult> UpdateUser(SharedUser.User user);
        Task<bool> IsAlreadyExists(string userName);

       Task<IdentityResult> GetUserByUsername(string userName);
        Task<bool> IsUserNameExist(string username);
        Task<SharedUser.User> GetById(string id);
        Task<SharedUser.User> GetUserByName(string userName);
        /* OLD METHOD FUNCTIONALITY*/
        //Task Create(SharedUser.User user);
        //Task Delete(SharedUser.User user);
        //Task<SharedUser.User> GetById(string id);
        //Task Update(SharedUser.User user);
        //Task<bool> AlreadyExist(string userName);
        //Task UpdateUser(string userId, string newUsername);
        //Task<SharedUser.User> GetUserByName(string userName);
        //Task<SharedUser.User> GetUserByNameWithPassword(string username);
        //Task GetAllPassword(SharedUser.User user);

        //Task<IEnumerable<SharedUser.User>> GetAllUsers();
    }
}
