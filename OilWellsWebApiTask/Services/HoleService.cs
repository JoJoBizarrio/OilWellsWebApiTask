using OilWellsWebApiTask.Data;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Models.Dtos;
using OilWellsWebApiTask.Repository;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Service
{
	public class HoleService : IHoleService
	{
		private readonly IRepository<Hole> _holes;

		public HoleService(DataContext dataContext)
		{
			_holes = new Repository<Hole>(dataContext);
		}

		public async Task AddAsync(AddHoleDto dto)
		{
			var hole = new Hole()
			{
				Name = dto.Name,
				Depth = dto.Depth,
				DrillBlockId = dto.DrillBlockId
			};

			await _holes.AddAsync(hole);
			await _holes.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			await _holes.DeleteAsync(id);
			await _holes.SaveAsync();
		}

		public async Task<List<GetHoleDto>> GetAllAsync()
		{
			var list = await _holes.GetAllAsync();
			var dtoList = new List<GetHoleDto>();

			foreach (var item in list)
			{
				dtoList.Add(new GetHoleDto
				{
					Id = item.Id,
					Name = item.Name,
					Depth = item.Depth,
					DrillBlockId = item.DrillBlockId
				});
			}

			return dtoList;
		}

		public async Task UpdateAsync(UpdateHoleDto dto)
		{
			var hole = new Hole()
			{
				Id = dto.Id,
				Name = dto.Name,
				Depth = dto.Depth,
				DrillBlockId = dto.DrillBlockId
			};

			_holes.Update(hole);
			await _holes.SaveAsync();
		}
	}
}