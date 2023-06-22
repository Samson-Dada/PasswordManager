using System.Linq.Expressions;

namespace API.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        //Task<IEnumerable<TEntity>> GetAllAsync();
        Task CreateAsync(TEntity entity);
        //Task UpdateAsync(TEntity entity);
        //void Delete(TEntity entity);
        //Task Delete(TEntity entity);

        //bool IsExist(int id);

    }
}
