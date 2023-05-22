namespace OilWellsWebApiTask.Service.Abstract
{
    public interface IBaseOperations<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
    }
}