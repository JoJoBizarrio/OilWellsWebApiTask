using OilWellsWebApiTask.Data;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Repository;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Service
{
	public class DrillBlockPointService : IDrillBlockPointService
	{
		private IRepository<DrillBlockPoint> _drillBlockPoints;

		public DrillBlockPointService(DataContext dataContext)
		{
			_drillBlockPoints = new Repository<DrillBlockPoint>(dataContext);
		}

		public async Task<List<DrillBlockPoint>> GetAllAsync()
		{
			return await _drillBlockPoints.GetAllAsync();
		}

		public async Task AddAsync(DrillBlockPoint drillBlockPoint)
		{
			await _drillBlockPoints.AddAsync(drillBlockPoint);
			await _drillBlockPoints.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			await _drillBlockPoints.DeleteAsync(id);
			await _drillBlockPoints.SaveAsync();
		}

		public async Task UpdateAsync(DrillBlockPoint drillBlockPoint)
		{
			_drillBlockPoints.Update(drillBlockPoint);
			await _drillBlockPoints.SaveAsync();
		}
	}
}