using API.DataAccess;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext ) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _dbContext.Users.Include(u => u.Password).ToListAsync();
            if (users is null)
            {
                return null;
            }
            return users;
        }

        public async Task Create(User user)
        {
            //string salt = BCrypt.Net.BCrypt.GenerateSalt();
            //user.Password = BCrypt.Net.BCrypt.HashPassword(user., salt);
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            await _dbContext.Users.Include(u => u.Password).ToListAsync();
        }

        public async Task Delete(User user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<User> GetById(int id)
        {
            var userId = await _dbContext.Users.Include(u => u.Password).SingleOrDefaultAsync(u => u.Id == id);
            if (userId is null)
            {
                return null;
            }
            return userId;
        }

        public async Task Update(User user)
        {
            var existingUser = await _dbContext.Users.Include(u => u.Password).SingleOrDefaultAsync(u => u.Id == user.Id);

            if (existingUser is null)
            {
                return;
            }

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;

            var existingPassword = existingUser.Password.FirstOrDefault(p => p.Id == user.Password.FirstOrDefault()?.Id);
            if (existingPassword != null)
            {
                existingPassword.Title = user.Password.FirstOrDefault()?.Title;
                existingPassword.HashedPassword = user.Password.FirstOrDefault()?.HashedPassword;
            }
            else
            {
                return;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(int userId, string newUsername)
        {
            var existingUser = await _dbContext.Users.FindAsync(userId);

            if (existingUser is null)
            {
                return;
            }
            
            existingUser.Username = newUsername;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> AlreadyExist(string userName)
        {
            bool isExist = await _dbContext.Users.Include(u => u.Password).AnyAsync(u => u.Username == userName);
            return isExist;
        }

        public async Task<User> GetUserByName(string userName)
        {

            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == userName);
            //var user = await _dbContext.Users.Include(userName).FirstOrDefaultAsync(u => u.Username == userName);
            if (user is null)
            {
                return null;
            }
            return user;
        }


        public async Task<User> GetUserByNameWithPassword(string username)
        {
            await GetUserByName(username);
            var user = await _dbContext.Users
                .Include(u=> u.Password)
                .Where(u => u.Username == username)
                .FirstOrDefaultAsync();
           
            return user;
        }

        public async Task GetAllPassword(User user)
        {
            await _dbContext.Users.Include(p => p.Password).ToListAsync();
        }
    }
}
