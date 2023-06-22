using API.Models;
using API.Repositories;

namespace API.DataAccess
{
    public interface IUnitOfWork:IDisposable
    {
        //IUserRepository UserRepository { get; }
        //IPasswordRepository PasswordRepository { get; }

        //IBaseRepository<User> UserRepository { get; }

        //void Save();

        Task SaveChangesAsync();
    }
}
