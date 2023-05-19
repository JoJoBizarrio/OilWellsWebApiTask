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

		public async Task<DrillBlock> GetSingeDrillBlockAsync(int id)
		{
			return await _dataContext.DrillBlocks.FindAsync(id);
		}

		public async Task<List<DrillBlock>> AddDrillBlockAsync(DrillBlock drillBlock)
		{
			await _dataContext.DrillBlocks.AddAsync(drillBlock);
			await _dataContext.SaveChangesAsync();

			return await _dataContext.DrillBlocks.ToListAsync();
		}

		public async Task<List<DrillBlock>> DeleteDrillBlockAsync(int id)
		{
			DrillBlock removedDrillBlock = await _dataContext.DrillBlocks.FindAsync(id);

			if (removedDrillBlock == null)
			{
				return null;
			}

			_dataContext.DrillBlocks.Remove(removedDrillBlock);

			await _dataContext.SaveChangesAsync();

			return await _dataContext.DrillBlocks.ToListAsync();
		}

		public async Task<List<DrillBlock>> UpdateDrillBlockAsync(int id, DrillBlock request)
		{
			DrillBlock updatedDrillBlock = await _dataContext.DrillBlocks.FindAsync(id);

			if (updatedDrillBlock == null)
			{
				return null;
			}

			updatedDrillBlock.Name = request.Name;
			updatedDrillBlock.LastUpdateDate = DateTime.UtcNow;

			await _dataContext.SaveChangesAsync();

			return await _dataContext.DrillBlocks.ToListAsync();
		}

		//public async Task<List<DrillBlockPoints>> GetAllDrillBlockPointsAsync()
		//{
		//	return await _dataContext.DrillBlockPoints.ToListAsync();
		//}

		//public async Task<List<Hole>> GetAllHolesAsync()
		//{
		//	return await _dataContext.Holes.ToListAsync();
		//}

		//public async Task<List<HolePoints>> GetAllHolePointsAsync()
		//{
		//	return await _dataContext.HolePoints.ToListAsync();
		//}
	}
}