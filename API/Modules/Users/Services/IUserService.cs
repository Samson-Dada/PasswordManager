using SharedUser = API.Shared.Entities;
namespace API.Modules.User.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(SharedUser.User user);
        Task<SharedUser.User> GetUserByIdAsync(string id);
        Task UpdateUserAsync(SharedUser.User user);
        Task DeleteUserAsync(SharedUser.User user);
        Task<bool> UserAlreadyExist(string userName);
        Task UpdateUserNameAsync(string userId, string userName);
        Task<SharedUser.User> GetUserByUserNameAsync(string userName);
        Task<SharedUser.User> GetUserNameWithPasswordAsync(string userName);
        Task GetUserNameWithAllPasswordAsync(SharedUser.User user);

    }
}
