using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Models.Dtos;

namespace OilWellsWebApiTask.Service.Abstract
{
	public interface IDrillBlockPointService
	{
		Task<List<GetDrillBlockPointDto>> GetAllAsync();
		Task AddAsync(AddDrillBlockPointDto dto);
		Task DeleteAsync(int id);
		Task UpdateAsync(UpdateDrillBlockPointDto dto);
	}
}