using API.Entities;

namespace API.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<bool> UserAlreadyExist(string userName);
        Task UpdateUserNameAsync(int userId, string userName);
        Task<User> GetUserByUserNameAsync(string userName);
        Task<User> GetUserNameWithPasswordAsync(string userName);
        Task GetUserNameWithAllPasswordAsync(User user);
    }
}
