using System.Linq.Expressions;

namespace OilWellsWebApiTask.Repository
{
	public interface IRepository<T> : IDisposable where T : class
	{
		IEnumerable<T> Get
			(Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>,
			IOrderedQueryable<T>> orderBy = null,
			string includeProperties = "");
		Task<List<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		Task AddAsync(T entity);
		Task DeleteAsync(int id);
		void Update(T entity);
		Task SaveAsync();
	}
}