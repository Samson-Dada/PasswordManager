using API.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

        private readonly DbSet<TEntity> _dbSet;
        private readonly ApplicationDbContext _dbContext;
        public BaseRepository(ApplicationDbContext dbContext) 
        {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();  
        }
        public async Task CreateAsync(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
             _dbSet.Remove(entity);
        }

      

        public IEnumerable<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities =await  _dbSet.ToListAsync();
            return entities;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
           var entityId = await _dbSet.FindAsync(id);
            if(entityId is null)
            {
                return null;
            }
            return entityId;
        }

        public bool IsExist(int id)
        {
           return _dbContext.Users.Any(x => x.Id == id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
           _dbContext.Update(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
           await  _dbContext.SaveChangesAsync();
        }
     
    }
}
