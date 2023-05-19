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

		Task<List<DrillBlockPoint>> GetAllDrillBlockPointsAsync();
		Task<List<DrillBlockPoint>> GetDrillBlockPointsByDrillBlockAsync(int idDrillBlock);
		Task<List<DrillBlockPoint>> AddDrillBlockPointAsync(DrillBlockPoint drillBlockPoints);
		Task<List<DrillBlockPoint>> DeleteDrillBlockPointAsync(int id);
		Task<List<DrillBlockPoint>> UpdateDrillBlockPointAsync(int id, DrillBlockPoint request);
	}
}