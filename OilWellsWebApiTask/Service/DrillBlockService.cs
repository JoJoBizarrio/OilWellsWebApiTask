using OilWellsWebApiTask.Data;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Repository;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Service
{
    public class DrillBlockService : IDrillBlockService
	{
		private IRepository<DrillBlock> _drillBlocks;

		public DrillBlockService(DataContext dataContext)
		{
			_drillBlocks = new Repository<DrillBlock>(dataContext);
		}

		public async Task<List<DrillBlock>> GetAllAsync()
		{
			return await _drillBlocks.GetAllAsync();
		}

		public async Task AddAsync(DrillBlock drillBlock)
		{
			await _drillBlocks.AddAsync(drillBlock);
			await _drillBlocks.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			await _drillBlocks.DeleteAsync(id);
			await _drillBlocks.SaveAsync();
		}

		public async Task UpdateAsync(DrillBlock drillBlock)
		{
			_drillBlocks.Update(drillBlock);
			await _drillBlocks.SaveAsync();
		}
	}
}