using API.Modules.User.Repositories;
using API.Shared.Entities;
using SharedUser = API.Shared.Entities;

namespace API.Modules.User.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordRepository _passwordRepository;
        public PasswordService(IPasswordRepository passwordRepository)
        {
            _passwordRepository = passwordRepository;
        }

        public async Task<IEnumerable<Password>> GetAllPassowordAsync()
        {
            var passwords = await _passwordRepository.GetAllPassword();
            return passwords;
        }


        // Search for save or stored password
        public async Task<IEnumerable<Password>> GetPasswordBySearchAsync(string passwordTitle)
        {
            var searchPassword = await _passwordRepository.GetPasswordBySearch(passwordTitle);
            return searchPassword;
        }


        // filter for save or stored password
        public async Task<IEnumerable<Password>> GetPasswordByFilterAsync(string passwordTitle)
        {
            var filterPassword = await _passwordRepository.GetPasswordByFilter(passwordTitle);
            return filterPassword;
        }
        public async Task<Password> GetPasswordByIdAsync(string passwordId)
        {
           var password = await _passwordRepository.GetById(passwordId);
            return password;
        }



        // Delete saved or stored password by user id
        public async Task<bool> DeletePasswordByUserIdAsync(string userId)
        {
            var userGuidAsString = userId.ToString();
            var isPasswordDeleted = await _passwordRepository.DeletePasswordByUserId(userGuidAsString);
            return isPasswordDeleted;
        }

        // Delete saved or stored password
        public async Task<Password> DeletePasswordAsync(string passwordId)
        {
            var passwordEntity = await _passwordRepository.DeletePassword(passwordId);
            return passwordEntity;
        }

        public string HashedPassword(string password)
        {
            return _passwordRepository.HashPassword(password);
        }


    }
}
