using Microsoft.EntityFrameworkCore;
using OilWellsWebApiTask.Data;

namespace OilWellsWebApiTask.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		internal readonly DataContext _dataContext;
		internal DbSet<T> DbSet;

		public Repository(DataContext dataContext)
		{
			_dataContext = dataContext;
			DbSet = _dataContext.Set<T>();
		}

		public async Task<IEnumerable<T>> GetAllAsync() // точно енмурэйбл? надо будет это проверить и перечитать 
		{
			return await DbSet.ToListAsync();
		}

		public async Task<T> GetSingleByIdAsync(int id)
		{
			return await DbSet.FindAsync(id);
		}

		public async Task AddAsync(T entity)
		{
			await DbSet.AddAsync(entity);
		}

		public async Task DeleteAsync(int id)
		{
			T deleted = await DbSet.FindAsync(id);
			DbSet.Remove(deleted);
		}

		public void Update(T entity)
		{
			DbSet.Update(entity);
		}

		public async Task SaveAsync()
		{
			await _dataContext.SaveChangesAsync();
		}


	}
}