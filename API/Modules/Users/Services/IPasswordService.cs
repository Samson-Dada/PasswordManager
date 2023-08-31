using API.Shared.Entities;
using SharedUser = API.Shared.Entities;

namespace API.Modules.User.Services
{
    public interface IPasswordService
    {
        Task<IEnumerable<Password>> GetAllPassowordAsync();
        Task GetPasswordByIdAsync(string id);
        Task CreatePasswordFromExisitingUserAsync(SharedUser.User existingUser, Password password);

        string HashedPassword(string password);
    }
}
