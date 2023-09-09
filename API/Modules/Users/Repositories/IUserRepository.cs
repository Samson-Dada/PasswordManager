using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedUser = API.Shared.Entities;

namespace API.Modules.User.Repositories
{
    public interface IUserRepository
    {
        /* NEW METHOD FUNCTIONALITY*/

        Task<IdentityResult> CreateUser(SharedUser.User user, string password);
        Task<IdentityResult> GetUserById(string id);
        Task<IdentityResult> DeleteUser(SharedUser.User user);
        Task<IdentityResult> UpdateUser(SharedUser.User user);
        Task<bool> AlreadyExists(string userName);

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
