using API.Shared.Entities;
using SharedUser = API.Shared.Entities;

namespace API.Modules.User.Services
{
    public interface IPasswordService
    {
        Task<IEnumerable<Password>> GetAllPassowordAsync();
        Task<Password> GetPasswordByIdAsync(string id);
        Task<IEnumerable<Password>> GetPasswordBySearchAsync(string passwordTitle);
        Task<Password> DeletePasswordAsync(string passwordId);
        Task<bool> DeletePasswordByUserIdAsync(string userId);
        Task<IEnumerable<Password>> GetPasswordByFilterAsync(string passwordTitle);
        string HashedPassword(string password);
    }
}
