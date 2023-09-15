using Microsoft.AspNetCore.Identity;
using SharedUser = API.Shared.Entities;
namespace API.Modules.User.Services
{
    public interface IUserService
    {

        /* NEW METHOD FUNCTIONALITY*/
        Task<IdentityUser> GetUserByIdAsync(string id);
        Task<IdentityResult> DeleteUserAsync(IdentityUser user);
        Task<IdentityResult> UpdateUserAsync(SharedUser.User user);
        Task<bool> IsUsernameAlreadyExists(string userName);
        Task<SharedUser.User> GetUserByUserNameAsync(string userName);
        Task<SharedUser.User> GetById(string id);
        //Task DeleteUserAsyncs(IdentityResult user);
        /* OLD METHOD FUNCTIONALITY*/


        //Task CreateUserAsync(SharedUser.User user);
        //Task<SharedUser.User> GetUserByIdAsync(string id);
        //Task UpdateUserAsync(SharedUser.User user);
        //Task DeleteUserAsync(SharedUser.User user);
        //Task<bool> UserAlreadyExist(string userName);
        //Task UpdateUserNameAsync(string userId, string userName);
        //Task<SharedUser.User> GetUserByUserNameAsync(string userName);
        //Task<SharedUser.User> GetUserNameWithPasswordAsync(string userName);
        //Task GetUserNameWithAllPasswordAsync(SharedUser.User user);


    }
}
