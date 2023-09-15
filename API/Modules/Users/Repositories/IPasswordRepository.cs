using API.Shared.Entities;
using SharedUser = API.Shared.Entities;


namespace API.Modules.User.Repositories
{
    public interface IPasswordRepository
    {

        string HashPassword(string password);
        Task<IEnumerable<Password>> GetAllPassword();
        Task<Password> GetById(string id);
        Task<IEnumerable<Password>> GetPasswordBySearch(string passwordTitle);
        Task<Password> DeletePassword(string passwordId);
        Task<bool> DeletePasswordByUserId(string userId);
        Task<IEnumerable<Password>> GetPasswordByFilter(string passwordTitle);
        ////    Task Update(Password password);

    }
}
