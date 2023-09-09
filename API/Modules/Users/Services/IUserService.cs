using Microsoft.AspNetCore.Identity;
using SharedUser = API.Shared.Entities;
namespace API.Modules.User.Services
{
    public interface IUserService
    {

        /* NEW METHOD FUNCTIONALITY*/
        //Task<IdentityResult> CreateUserAsyncs(SharedUser.User user, string password);
        Task<IdentityResult> GetUserByIdAsyncs(string id);
        Task<IdentityResult> DeleteUserAsyncs(SharedUser.User user);
        Task<IdentityResult> UpdateUserAsync(SharedUser.User user);
        Task<bool> UserAlreadyExists(string userName);

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

        //Task<IEnumerable<SharedUser.User>> GetAllUsersAsync();

    }
}
