namespace Application.Common.Interfaces
{
    public interface IRepository<T>
    {
        Task<int> AddAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<List<T?>> GetAllAsync();
        Task<int> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
