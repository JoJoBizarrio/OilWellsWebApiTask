using OilWellsWebApiTask.Models.Dtos;

namespace OilWellsWebApiTask.Service.Abstract
{
    public interface IHoleService
	{
		Task<List<GetHoleDto>> GetAllAsync();
		Task AddAsync(AddHoleDto dto);
		Task DeleteAsync(int id);
		Task UpdateAsync(UpdateHoleDto dto);
	}
}