using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Models.Dtos;

namespace OilWellsWebApiTask.Service.Abstract
{
	public interface IHolePointService
	{
		Task<ResponseService<List<GetHolePointDto>>> GetAllAsync();
		Task<ResponseService<List<GetHolePointDto>>> AddAsync(AddHolePointDto dto);
		Task<ResponseService<List<GetHolePointDto>>> DeleteAsync(int id);
		Task<ResponseService<GetHolePointDto>> UpdateAsync(UpdateHolePointDto dto);
	}
}