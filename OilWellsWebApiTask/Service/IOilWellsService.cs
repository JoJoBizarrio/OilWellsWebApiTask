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

		Task<List<Hole>> GetAllHolesAsync();
		Task<List<Hole>> GetHolesByDrillBlockAsync(int idDrillBlock);
		Task<List<Hole>> AddHoleAsync(Hole hole);
		Task<List<Hole>> DeleteHoleAsync(int id);
		Task<List<Hole>> UpdateHoleAsync(int id, Hole request);

		Task<List<HolePoint>> GetAllHolePointsAsync();
		Task<List<HolePoint>> AddHolePointAsync(HolePoint holePoint);
		Task<List<HolePoint>> DeleteHolePointAsync(int id);
		Task<List<HolePoint>> UpdateHolePointAsync(int id, HolePoint request);
	}
}