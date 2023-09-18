using Microsoft.AspNetCore.Identity;
using SharedUser = API.Shared.Entities;
namespace API.Modules.User.Services
{
    public interface IUserService
    {
        Task<IdentityUser> GetUserByIdAsync(string id);
        Task<IdentityResult> DeleteUserAsync(IdentityUser user);
        Task<IdentityResult> UpdateUserAsync(SharedUser.User user);
        Task<bool> IsUsernameAlreadyExists(string userName);
        Task<SharedUser.User> GetUserByUserNameAsync(string userName);
        Task<SharedUser.User> GetById(string id);
    }
}
