using API.Models;

namespace API.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
    }
}
