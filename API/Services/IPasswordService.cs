using API.Entities;

namespace API.Services
{
    public interface IPasswordService
    {
        Task<IEnumerable<Password>> GetAllPassowordAsync();
        Task GetPasswordByIdAsync(string id);
        Task CreatePasswordFromExisitingUserAsync(User existingUser, Password password);

        string HashedPassword(string password);
    }
}
