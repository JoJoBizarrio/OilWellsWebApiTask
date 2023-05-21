namespace OilWellsWebApiTask.Repository
{
	public interface IRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetSingleByIdAsync(int id);
		Task AddAsync(T entity);
		Task DeleteAsync(int id);
		void Update(T entity);
		Task SaveAsync();
	}
}