using API.Shared.DataAccess;
using API.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using API.Shared.Utilities.Encryptions;

namespace API.Modules.User.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public PasswordRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Password>> GetAllPassword()
        {
            var passwords = await _dbContext.Password.ToListAsync();
            return passwords;
        }

        //
        public async Task<Password> DeletePassword(string passwordId)
        {
            var passwordToDelete = await _dbContext.Password.FirstOrDefaultAsync(x => x.Id == passwordId);
            if (passwordToDelete is null)
            {
               return null;
            }
            _dbContext.Password.Remove(passwordToDelete);
           await _dbContext.SaveChangesAsync();
            return passwordToDelete;
        }


        public async Task<bool> DeletePasswordByUserId(string userId)
        {
            var userGuidAsString = userId.ToString();
            var savePassword = await _dbContext.Password.FirstOrDefaultAsync(x => x.UserId == userGuidAsString);

            if (savePassword is null)
            {
                return false; 
            }

            _dbContext.Password.Remove(savePassword);
            await _dbContext.SaveChangesAsync();

            return true;
        }




        // Get password by ID
        public async Task<Password> GetById(string passwordId)
        {
            var password = await _dbContext.Password.SingleOrDefaultAsync(x => x.Id == passwordId);
            if (password is null)
            {
                return null;
            }
            return password;
        }

        // Search for password by title
        public async Task<IEnumerable<Password>> GetPasswordBySearch(string passwordTitle)
        {
            if (string.IsNullOrEmpty(passwordTitle) && string.IsNullOrWhiteSpace(passwordTitle))
            {
                return await GetAllPassword();
            }
            var collection = _dbContext.Password as IQueryable<Password>;
            passwordTitle = passwordTitle.Trim();
            var result = await collection
             .Where(t => t.Title.Contains(passwordTitle))
             .OrderBy(t => t.Title)
             .ToListAsync();

            return result.Any() ? result : await GetAllPassword();
        }


        // Filter for password by title
        public async Task<IEnumerable<Password>> GetPasswordByFilter(string passwordTitle)
        {

            if (string.IsNullOrWhiteSpace(passwordTitle))
            {
                return await GetAllPassword();
            }

            passwordTitle = passwordTitle.Trim();
            var result = await _dbContext.Password
                 .Where(title => title.Title == passwordTitle)
                 .OrderBy(title => title.Title)
                 .ToListAsync();
            return result.Any() ? result : await GetAllPassword();
        }

        // Password hashing
        public string HashPassword(string password)
        {
            string passwordToHash = PasswordHash.GenerateHashPassword(password);
            return passwordToHash;
        }



    }
}