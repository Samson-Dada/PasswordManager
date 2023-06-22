using API.DataAccess;
using API.Models;

namespace API.Repositories
{
    public class PasswordRepository: IPasswordRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public PasswordRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Password> GetByIdAsync(int id)
        {
            var password = await _dbContext.Passwords.FindAsync(id);
            return password;
        }

        public async Task AddAsync(Password password)
        {
          await  _dbContext.Passwords.AddAsync(password);
        }
      

        public Task CreateAsync(Password password)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Password password)
        {
            _dbContext.Passwords.Update(password);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Password password)
        {
           _dbContext.Remove(password);
            return Task.CompletedTask;
        }
    }
}
