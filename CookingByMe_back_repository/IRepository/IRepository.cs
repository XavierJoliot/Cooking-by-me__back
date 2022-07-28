using System.Linq.Expressions;

namespace CookingByMe_back.Core.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FindAll();

        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);

        Task<TEntity?> FindEntityAsync(int id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task SaveAsync();
    }
}
