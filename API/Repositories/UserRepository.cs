using API.DataAccess;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class UserRepository :IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<IEnumerable<User>> GetAll() 
        {
         var users = await _dbContext.Users.ToListAsync();
            if(users is null)
            {
                return null;
            }
            return users;   
        }
        public async Task Create(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
         _dbContext.Users.Remove(user);
          await  _dbContext.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<User> GetById(int id)
        {
           var userId =await  _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
            if(userId is null)
            {
                return null;
            }
            return userId;
        }

        public async Task Update(User user)
        {
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        //public Task Update(User user)
        //{
        //  _dbContext.Update(user);
        //   _dbContext.Entry(user).State = EntityState.Modified;
        //     _dbContext.SaveChanges();
        //}

        //public async Task CreateAsync(User entity)
        //{
        //    await _dbContext.Set<User>().AddAsync(entity);
        //}

        //public async Task<User> GetByIdAsync(int id)
        //{
        //    return await _dbContext.Set<User>().FindAsync(id);
        //}


        //public async Task CreateAsync(User user)
        //{
        //   await  _dbContext.Users.AddAsync(user);
        //}

        //public Task DeleteAsync(User user)
        //{
        //   _dbContext.Users.Remove(user);
        //    return Task.CompletedTask;
        //}

        //public async Task<User> GetByIdAsync(int id)
        //{
        //    return await _dbContext.Users.FindAsync(id); 
        //}

        //public Task UpdateAsync(User user)
        //{
        //    _dbContext.Users.Update(user);
        //    return Task.CompletedTask;
        //}
    }
}
