namespace OilWellsWebApiTask.Repository
{
	public interface IRepository<T> : IDisposable where T : class
	{
		Task<List<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		Task AddAsync(T entity);
		Task DeleteAsync(int id);
		void Update(T entity);
		Task SaveAsync();
	}
}