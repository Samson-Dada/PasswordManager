using API.Models;
using API.Repositories;

namespace API.DataAccess
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _dbcontext;

        private IUserRepository _userRepository;

        //private  readonly IBaseRepository<User> _userRepository;

        public UnitOfWork(ApplicationDbContext dbContext, IUserRepository userRepository)
        {
            _dbcontext = dbContext;
            _userRepository = userRepository ;
        }

        public IUserRepository UserRepository => _userRepository;


        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        public async Task SaveChangesAsync()
        {
       await _dbcontext.SaveChangesAsync();
        }

       

        //public async Task<int> SaveAsync()
        //{
        // var saveChanges =  await _dbcontext.SaveChangesAsync();
        //    return saveChanges;
        //}
    }
}
