using OilWellsWebApiTask.Models;

namespace OilWellsWebApiTask.Service
{
	public interface IOilWellsService
	{
		Task<List<DrillBlock>> GetAllDrillBlocksAsync();
		Task AddDrillBlockAsync(DrillBlock drillBlock);

	}
}
