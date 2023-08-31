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
            var passwords = await _passwordRepository.GetAll();
            return passwords;
        }

        public async Task GetPasswordByIdAsync(string id)
        {
            await _passwordRepository.GetById(id);
        }

        public Task CreatePasswordFromExisitingUserAsync(SharedUser.User existingUser, Password password)
        {
            var user = _passwordRepository.Create(existingUser, password);
            return user;
        }

        public string HashedPassword(string password)
        {
            return _passwordRepository.HashPassword(password);
        }


    }
}
