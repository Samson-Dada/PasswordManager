using API.Models;

namespace API.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task Create(User user);
        Task Delete(User user);
        Task Update(User user);
    }
}
