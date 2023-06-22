using API.Models;

namespace API.Repositories
{
    public interface IPasswordRepository
    {

        Task<Password> GetByIdAsync(int id);
        Task CreateAsync(Password password);
        Task UpdateAsync(Password password);
        Task DeleteAsync(Password password);
    }
}
