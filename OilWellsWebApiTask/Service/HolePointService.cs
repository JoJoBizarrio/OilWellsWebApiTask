using OilWellsWebApiTask.Data;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Repository;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Service
{
	public class HolePointService : IHolePointService
	{
		private IRepository<HolePoint> _holePoints;

		public HolePointService(DataContext dataContext)
		{
			_holePoints = new Repository<HolePoint>(dataContext);
		}

		public async Task<List<HolePoint>> GetAllAsync()
		{
			return await _holePoints.GetAllAsync();
		}

		public async Task AddAsync(HolePoint holePoint)
		{
			await _holePoints.AddAsync(holePoint);
			await _holePoints.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			await _holePoints.DeleteAsync(id);
			await _holePoints.SaveAsync();
		}

		public async Task UpdateAsync(HolePoint holePoint)
		{
			_holePoints.Update(holePoint);
			await _holePoints.SaveAsync();
		}
	}
}