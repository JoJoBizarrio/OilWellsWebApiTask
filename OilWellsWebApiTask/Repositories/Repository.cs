using Microsoft.EntityFrameworkCore;
using OilWellsWebApiTask.Data;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OilWellsWebApiTask.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly DataContext _dataContext;
		private DbSet<T> _dbSet;

		private bool disposed = false;

		public Repository(DataContext dataContext)
		{
			_dataContext = dataContext;
			_dbSet = _dataContext.Set<T>();
		}

		public IEnumerable<T> Get(
		  Expression<Func<T, bool>> filter = null,
		  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
		  string includeProperties = "")
		{
			IQueryable<T> query = _dbSet;

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
			return await _dbSet.ToListAsync();
		}

		public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = _dbSet;

			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}

			return query;
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public async Task DeleteAsync(int id)
		{
			T deleted = await _dbSet.FindAsync(id);
			_dbSet.Remove(deleted);
		}

		public void Update(T entity)
		{
			_dbSet.Entry(entity).State = EntityState.Modified;
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