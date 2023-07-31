using API.Entities;

namespace API.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(string id);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<bool> UserAlreadyExist(string userName);
        Task UpdateUserNameAsync(string userId, string userName);
        Task<User> GetUserByUserNameAsync(string userName);
        Task<User> GetUserNameWithPasswordAsync(string userName);
        Task GetUserNameWithAllPasswordAsync(User user);

        Task<IEnumerable<User>> AllUserByPagination(int pageNumber, int pageSize);

    }
}
