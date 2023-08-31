using API.Shared.DataAccess;
using SharedUser = API.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.Repositories
{
    public class AdminRepository: IAdminRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AdminRepository(ApplicationDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SharedUser.User>> GetAll()
        {
            var users = await _dbContext.Users.Include(u => u.Password).ToListAsync();
            if (users is null)
            {
                return null;
            }
            return users;
        }
        public async Task<SharedUser.User> GetById(string id)
        {
            var userId = await _dbContext.Users.Include(u => u.Password).SingleOrDefaultAsync(u => u.Id == id);
            if (userId is null)
            {
                return null;
            }
            return userId;
        }
        public async Task<SharedUser.User> GetUserByName(string userName)
        {

            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == userName);
            //var user = await _dbContext.Users.Include(userName).FirstOrDefaultAsync(u => u.Username == userName);
            if (user is null)
            {
                return null;
            }
            return user;
        }


        public async Task<SharedUser.User> GetUserByNameWithPassword(string username)
        {
            await GetUserByName(username);
            var user = await _dbContext.Users
                .Include(u=> u.Password)
                .Where(u => u.Username == username)
                .FirstOrDefaultAsync();

            return user;
        }
    }
}
