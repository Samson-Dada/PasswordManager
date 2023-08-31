using API.Shared.Entities;
using SharedUser = API.Shared.Entities;

namespace API.Modules.Services
{
    public interface IAdminService
    {
        Task<SharedUser.User> GetUserByIdAsync(string id);
        Task<IEnumerable<SharedUser.User>> GetAllUserAsync();
        //Task<bool> UserAlreadyExist(string userName);
        Task< SharedUser.User> GetUserByUserNameAsync(string userName);
    }
}
