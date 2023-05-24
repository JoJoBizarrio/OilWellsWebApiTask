using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Models.Dtos;

namespace OilWellsWebApiTask.Service.Abstract
{
	public interface IDrillBlockService
	{
		Task<ResponseService<List<GetDrillBlockDto>>> GetAllAsync();
		Task<ResponseService<List<GetDrillBlockDto>>> AddAsync(AddDrillBlockDto dto);
		Task<ResponseService<List<GetDrillBlockDto>>> DeleteAsync(int id);
		Task<ResponseService<GetDrillBlockDto>> UpdateAsync(UpdateDrillBlockDto dto);
	}
}