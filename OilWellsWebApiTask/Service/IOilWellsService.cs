using OilWellsWebApiTask.Models;

namespace OilWellsWebApiTask.Service
{
	public interface IOilWellsService
	{
		Task<List<DrillBlock>> GetAllDrillBlocksAsync();
		Task<DrillBlock> GetSingeDrillBlockAsync(int id);
		Task<List<DrillBlock>> AddDrillBlockAsync(DrillBlock drillBlock);
		Task<List<DrillBlock>> DeleteDrillBlockAsync(int id);
		Task<List<DrillBlock>> UpdateDrillBlockAsync(int id, DrillBlock request);

	}
}
