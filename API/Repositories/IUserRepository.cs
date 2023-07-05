using API.Entities;

namespace API.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task Create(User user);
        Task Delete(User user);
        Task<User> GetById(int id);
        Task Update(User user);
        Task<bool> AlreadyExist(string userName);
        Task UpdateUser(int userId, string newUsername);
        Task<User> GetUserByName(string userName);
        Task<User> GetUserByNameWithPassword(string username);
        Task GetAllPassword(User user);
    }
}
