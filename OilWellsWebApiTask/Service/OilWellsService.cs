using Microsoft.EntityFrameworkCore;
using OilWellsWebApiTask.Data;
using OilWellsWebApiTask.Models;

namespace OilWellsWebApiTask.Service
{
	public class OilWellsService : IOilWellsService
	{
		private readonly DataContext _dataContext;

		public OilWellsService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<List<DrillBlock>> GetAllDrillBlocksAsync()
		{
			return await _dataContext.DrillBlocks.ToListAsync();
		}

		public async Task<List<DrillBlockPoints>> GetAllDrillBlockPointsAsync()
		{
			return await _dataContext.DrillBlockPoints.ToListAsync();
		}

		public async Task<List<Hole>> GetAllHolesAsync()
		{
			return await _dataContext.Holes.ToListAsync();
		}

		public async Task<List<HolePoints>> GetAllHolePointsAsync()
		{
			return await _dataContext.HolePoints.ToListAsync();
		}

		public async Task AddDrillBlockAsync(DrillBlock drillBlock)
		{
			await _dataContext.DrillBlocks.AddAsync(drillBlock);
			await _dataContext.SaveChangesAsync();
		}
	}
}