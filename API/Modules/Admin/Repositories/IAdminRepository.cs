using SharedUser = API.Shared.Entities;

namespace API.Modules.Repositories
{
    public interface IAdminRepository
    {
        Task<IEnumerable<SharedUser.User>> GetAll();
        Task<SharedUser.User> GetById(string id);
        Task<IEnumerable<SharedUser.User>> GetUsersByPage(int pageNumber, int pageSize);
    }
}
