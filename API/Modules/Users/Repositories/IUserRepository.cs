using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedUser = API.Shared.Entities;

namespace API.Modules.User.Repositories
{
    public interface IUserRepository
    {
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
        Task<IdentityResult> UpdateUsername(IdentityUser user);
    }
}
