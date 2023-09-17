using SharedUser =  API.Shared.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Modules.User.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<SharedUser.User> _userManager;
        public UserRepository(UserManager<SharedUser.User> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IdentityUser> GetUserById(string id)
        {
            var existingUser = await _userManager.FindByIdAsync(id);
            return existingUser;
        }
        private async Task<IdentityUser> UserExist(string id)
        {
            var userId = await _userManager.FindByIdAsync(id);
            if (userId == null)
            {
                return null;
            }
            return userId;

        }


        public async Task<IdentityResult> UpdateUser(SharedUser.User user)
        {
            SharedUser.User existingUser = await _userManager.FindByIdAsync(user.Id);
            if (existingUser == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            return await _userManager.UpdateAsync(existingUser);
        }



        // Delete a user
        public async Task<IdentityResult> DeleteUser(SharedUser.User user)
        {
            // Check if the user exists before attempting to delete
            SharedUser.User existingUser = await _userManager.FindByIdAsync(user.Id);
            if (existingUser == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            IdentityResult deleteUser = await _userManager.DeleteAsync(existingUser);
            return deleteUser;
        }

        /*...........*/

        // Delete a user
        public async Task<IdentityResult> DeleteUser(IdentityUser user)
        {
            // Check if the user exists before attempting to delete
            SharedUser.User existingUser = await _userManager.FindByIdAsync(user.Id);
            if (existingUser == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            IdentityResult deleteUser = await _userManager.DeleteAsync(existingUser);
            return deleteUser;
        }

        // options 1
        public async Task<IdentityResult> GetUserByUsername(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Cannot found username, try another" });
            }
            return IdentityResult.Success;
        }

        // options 2
        public async Task<bool> IsUserNameExist(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user != null;
        }

        // options 3
        public async Task<bool> IsAlreadyExists(string userName)
        {
            IdentityUser userExist = await _userManager.FindByNameAsync(userName);
            return userExist != null;
        }


        public async Task<SharedUser.User> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return user;
        }


        //
        public async  Task<IdentityResult> CreateUser(SharedUser.User user, string password)
        {
            IdentityResult newUser = await _userManager.CreateAsync(user, password);
            return newUser;
        }

        //
        public async Task<SharedUser.User> GetUserByName(string userName)
        {

            var user = await _userManager.FindByNameAsync(userName);
            //var user = await _dbContext.Users.Include(userName).FirstOrDefaultAsync(u => u.Username == userName);
            if (user is null)
            {
                return null;
            }
            return user;
        }

        // TODO :: Use Microsoft Identity for updating user
               // check the below method

        /* OLD METHOD FUNCTIONALITY*/

        //public async Task Update(SharedUser.User user)
        //{
        //    var existingUser = await _dbContext.AppUsers.Include(u => u.Password).SingleOrDefaultAsync(u => u.Id == user.Id);

        //    if (existingUser is null)
        //    {
        //        return;
        //    }

        //    existingUser.UserName = user.UserName;
        //    existingUser.Email = user.Email;

        //    var existingPassword = existingUser.Password.FirstOrDefault(p => p.Id == user.Password.FirstOrDefault()?.Id);
        //    if (existingPassword != null)
        //    {
        //        existingPassword.Title = user.Password.FirstOrDefault()?.Title;
        //        existingPassword.HashedPassword = user.Password.FirstOrDefault()?.HashedPassword;
        //    }
        //    else
        //    {
        //        return;
        //    }
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task UpdateUser(string userId, string newUsername)
        //{
        //    var existingUser = await _dbContext.AppUsers.FindAsync(userId);

        //    if (existingUser is null)
        //    {
        //        return;
        //    }

        //    existingUser.UserName = newUsername;
        //    await _dbContext.SaveChangesAsync();
        //}
    }
}
