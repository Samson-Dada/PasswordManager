using API.Shared.DataAccess;
using API.Shared.Entities;
using SharedUser = API.Shared.Entities;
using API.Shared.Utilities;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.User.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public PasswordRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public async Task<IEnumerable<Password>> GetAll()
        //{
        //    var passwords = await _dbContext.Passwords.ToListAsync();
        //    return passwords;
        //}

        //public async Task GetById(string id)
        //{
        //    var password = await _dbContext.Passwords.SingleOrDefaultAsync(x => x.Id == id);
        //    if (password is null)
        //    {
        //        return;
        //    }
        //}

        //public async Task Create(SharedUser.User existingUser, Password password)
        //{
        //    string salt = BCrypt.Net.BCrypt.GenerateSalt();
        //    BCrypt.Net.BCrypt.HashPassword(password.HashedPassword, salt);
        //    var user = await _dbContext.AppUsers.SingleOrDefaultAsync(u => u.UserName == existingUser.UserName);
        //    if (user is null)
        //    {
        //        return;
        //    }
        //    user = existingUser;
        //    password.Id = Guid.NewGuid().ToString();
        //    existingUser.Password.Add(password);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task AddPassword(User existingUser, string title, string hashedPassword)
        //{
        //    var newPassword = new Password
        //    {
        //        Title = title,
        //        HashedPassword = hashedPassword
        //    };

        //    existingUser.Password.Add(newPassword);
        //    await _dbContext.SaveChangesAsync();
        //}



        // Continue from here
        //public async Task<IEnumerable<Password>> SearchPassword(string passwordTitle)
        //{
        //    if (string.IsNullOrEmpty(passwordTitle) && string.IsNullOrWhiteSpace(passwordTitle))
        //    {
        //        return await GetAll();
        //    }
        //    var collection = _dbContext.Passwords as IQueryable<Password>;

        //    if (!string.IsNullOrWhiteSpace(passwordTitle))
        //    {
        //        passwordTitle = passwordTitle.Trim();
        //        collection = collection.Where(t => t.Title.Contains(passwordTitle));
        //    }

        //    Task<List<Password>> task = collection.OrderBy(x => x.Title).ToListAsync();
        //    return await task;
        //}

        //public string HashPassword(string password)
        //{

        //    return PasswordHash.GenerateHashPassword(password);
        //    //    using SHA256 sha256 = SHA256.Create();
        //    //    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        //    //    byte[] hashedBytes = sha256.ComputeHash(passwordBytes);

        //    //    string hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        //    //    return hashedPassword;
        //}
    }
}




///  a method that create passoword when existing
///  user is provided, without creating another one/