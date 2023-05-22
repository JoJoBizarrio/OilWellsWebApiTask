using OilWellsWebApiTask.Data;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Repository;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Service
{
	public class HoleService : IHoleService
	{
		private IRepository<Hole> _holes;

		public HoleService(DataContext dataContext)
		{
			_holes = new Repository<Hole>(dataContext);
		}

		public async Task<List<Hole>> GetAllAsync()
		{
			return await _holes.GetAllAsync();
		}

		public async Task AddAsync(Hole holePoint)
		{
			await _holes.AddAsync(holePoint);
			await _holes.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			await _holes.DeleteAsync(id);
			await _holes.SaveAsync();
		}

		public async Task UpdateAsync(Hole holePoint)
		{
			_holes.Update(holePoint);
			await _holes.SaveAsync();
		}
	}
}