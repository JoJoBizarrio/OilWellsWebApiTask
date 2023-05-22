using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Models.Dtos;

namespace OilWellsWebApiTask.Service.Abstract
{
    public interface IDrillBlockService 
	{
		Task<List<GetDrillBlockDto>> GetAllAsync();
		Task AddAsync(AddDrillBlockDto dto);
		Task DeleteAsync(int id);
		Task UpdateAsync(UpdateDrillBlockDto dto);
	}
}