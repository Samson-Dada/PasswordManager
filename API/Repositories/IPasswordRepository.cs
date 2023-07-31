using API.Entities;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IPasswordRepository
    {
        //    Task<IEnumerable<Password>> GetAll();
        Task<IEnumerable<Password>> GetAll();
        Task GetById(string id);
        Task Create(User existingUser, Password password);
        //    Task Update(Password password);
        string HashPassword(string password);

    }
}
