using API.Shared.DataAccess;
using SharedUser = API.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace API.Modules.Repositories
{
    public class AdminRepository: IAdminRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<SharedUser.User> _userManager;
        //public AdminRepository(UserManager<SharedUser.User> userManager, ApplicationDbContext dbContext)
        //{
        //    _userManager = userManager;
        //    _dbContext = dbContext;
        //}

        public AdminRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // Get All users
        public async Task<IEnumerable<SharedUser.User>> GetAll()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users;
        }


        // Get user by Id
        public async Task<SharedUser.User> GetById(string id)
        {
            var userById = await _dbContext.Users.Include(u => u.Password).SingleOrDefaultAsync(u => u.Id == id);
            return userById;
        }


        public async Task<IEnumerable<SharedUser.User>> GetUsersByPage(int pageNumber, int pageSize)
        {

            var collections = _dbContext.Users as IQueryable<SharedUser.User>;
            var itemsToSkip = (pageNumber - 1) - pageSize;
            var users = await collections
                .Skip(itemsToSkip)
                .Take(pageSize)
                .OrderBy(u => u.UserName)
                .ToListAsync();
            return users;
        }
    }
}
