using Microsoft.EntityFrameworkCore;
using OilWellsWebApiTask.Data;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OilWellsWebApiTask.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		internal readonly DataContext _dataContext;
		internal DbSet<T> DbSet;

		private bool disposed = false;

		public Repository(DataContext dataContext)
		{
			_dataContext = dataContext;
			DbSet = _dataContext.Set<T>();
		}

		public IEnumerable<T> Get(
		  Expression<Func<T, bool>> filter = null,
		  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
		  string includeProperties = "")
		{
			IQueryable<T> query = DbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				return orderBy(query).ToList();
			}

			return query.ToList();
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await DbSet.ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
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
			DbSet.Entry(entity).State = EntityState.Modified;
		}

		public async Task SaveAsync()
		{
			await _dataContext.SaveChangesAsync();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					_dataContext.Dispose();
				}

				disposed = true;
			}
		}
	}
}