using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Models.Dtos;

namespace OilWellsWebApiTask.Service.Abstract
{
	public interface IDrillBlockPointService
	{
		Task<ResponseService<List<GetDrillBlockPointDto>>> GetAllAsync();
		Task<ResponseService<List<GetDrillBlockPointDto>>> AddAsync(AddDrillBlockPointDto dto);
		Task<ResponseService<List<GetDrillBlockPointDto>>> DeleteAsync(int id);
		Task<ResponseService<GetDrillBlockPointDto>> UpdateAsync(UpdateDrillBlockPointDto dto);
	}
}