using API.Modules.Repositories;
using API.Modules.User.Repositories;
using API.Shared.Entities;
using SharedUser = API.Shared.Entities;

namespace API.Modules.Services
{
    public class AdminService: IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(AdminService));
        }


        public async Task<IEnumerable<SharedUser.User>> GetAllUserAsync()
        {
            var users = await _adminRepository.GetAll();
            return users;
        }


        public async Task<SharedUser.User> GetUserByIdAsync(string userId)
        {
            var user = await _adminRepository.GetById(userId);
            return user;
        }

        public async Task<IEnumerable<SharedUser.User>> GetUsersByPagination(int pageNumber, int pageSize)
        {
            var usersPagination = await _adminRepository.GetUsersByPage(pageNumber, pageSize);
            return usersPagination;
        }
    }
}
