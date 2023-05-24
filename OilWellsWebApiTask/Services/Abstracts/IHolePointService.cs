using OilWellsWebApiTask.Models.Dtos;

namespace OilWellsWebApiTask.Service.Abstract
{
	public interface IHolePointService
	{
		Task<List<GetHolePointDto>> GetAllAsync();
		Task AddAsync(AddHolePointDto dto);
		Task DeleteAsync(int id);
		Task UpdateAsync(UpdateHolePointDto dto);
	}
}