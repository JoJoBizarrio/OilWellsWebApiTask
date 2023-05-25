using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Models.Dtos;

namespace OilWellsWebApiTask.Service.Abstract
{
	public interface IHoleService
	{
		Task<ResponseService<List<GetHoleDto>>> GetAllAsync();
		Task<ResponseService<List<GetHoleDto>>> AddAsync(AddHoleDto dto);
		Task<ResponseService<List<GetHoleDto>>> DeleteAsync(int id);
		Task<ResponseService<GetHoleDto>> UpdateAsync(UpdateHoleDto dto);
	}
}