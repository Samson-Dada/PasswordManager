using SharedUser = API.Shared.Entities;

namespace API.Modules.User.Repositories
{
    public interface IUserRepository
    {
        Task Create(SharedUser.User user);
        Task Delete(SharedUser.User user);
        Task<SharedUser.User> GetById(string id);
        Task Update(SharedUser.User user);
        Task<bool> AlreadyExist(string userName);
        Task UpdateUser(string userId, string newUsername);
        Task<SharedUser.User> GetUserByName(string userName);
        Task<SharedUser.User> GetUserByNameWithPassword(string username);
        Task GetAllPassword(SharedUser.User user);
    }
}
