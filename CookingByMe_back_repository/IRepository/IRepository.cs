namespace CookingByMe_back.Core.IRepository
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAllAsync();

        public Task<T> GetByIdAsync(int id);

        public Task<T> AddAsync(T entity);

        public Task<T> UpdateAsync(T entity);

        public Task<bool> Delete(int id);

        public Task<bool> SaveAsync();
    }
}
