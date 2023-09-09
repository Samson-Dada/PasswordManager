using API.Modules.Repositories;
using API.Modules.User.Repositories;
using API.Shared.Entities;
using SharedUser = API.Shared.Entities;

namespace API.Modules.Services
{
    public class AdminService: IAdminService
    {
        //private readonly IAdminRepository _adminRepository;
        //public AdminService(IAdminRepository adminRepository)
        //{
        //    _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(AdminService));
        //}

        //public async Task<IEnumerable<SharedUser.User>> GetAllUserAsync()
        //{
        //    var users = await _adminRepository.GetAll();
        //    return users;
        //}

        //public async Task<SharedUser.User> GetUserByIdAsync(string id)
        //{
        //    var user = await _adminRepository.GetById(id);
        //    if (user is null)
        //    {
        //        return null;
        //    }
        //    return user;
        //}


        //public async Task<bool> UserAlreadyExist(string userName)
        //{
        //    bool isExist = await _adminRepository.AlreadyExist(userName);
        //    return isExist;
        //}

        //public async Task<SharedUser.User> GetUserByUserNameAsync(string userName)
        //{
        //    var user = await _adminRepository.GetUserByName(userName);
        //    return user;
        //}


       //public async Task<IEnumerable<SharedUser.User>> GetAllPagination(int pageNumber, int pageSize)
       // {
       //     var usersPagination = await _adminRepository.GetPagination(pageNumber, pageSize);
       //     return usersPagination;
       // }
    }
}
