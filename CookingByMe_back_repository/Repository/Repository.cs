using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Core;
using System.Linq.Expressions;

namespace CookingByMe_back.Core.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly CookingByMeContext context;

        public Repository(CookingByMeContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> FindAll()
        {
            return context.Set<TEntity>().AsNoTracking();
        }


        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return context.Set<TEntity>().Where(expression).AsNoTracking();
        }

        public void Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }
        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }
        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
