using API.Entities;

namespace API.Services
{
    public interface IPasswordService
    {
        Task<IEnumerable<Password>> GetAllPassowordAsync();
        Task GetPasswordByIdAsync(int id);
        Task CreatePasswordFromExisitingUserAsync(User existingUser, Password password);

        string HashedPassword(string password);


    }
}
