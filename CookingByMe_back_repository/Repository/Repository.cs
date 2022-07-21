using CookingByMe_back.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingByMe_back.Core.Repository
{
    public class Repository<T> : IRepository<T> where T : new()
    {
        public Task<List<T>> GetAllAsync()
        {
            return Task.FromResult(new List<T>());
        }


        public Task<T> GetByIdAsync(int id)
        {
            T entity = new();
            return Task.FromResult(entity);
        }

        public Task<T> AddAsync(T entity)
        {
            return Task.FromResult(entity);
        }

        public Task<T> UpdateAsync(T entity)
        {
            return Task.FromResult(entity);
        }

        public Task<bool> Delete(int id)
        {
            return Task.FromResult(true);
        }

        public Task<bool> SaveAsync()
        {
            return Task.FromResult(false);
        }
    }
}
