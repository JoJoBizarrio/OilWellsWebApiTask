using OilWellsWebApiTask.Data;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Models.Dtos;
using OilWellsWebApiTask.Repository;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Service
{
	public class HolePointService : IHolePointService
	{
		private readonly IRepository<HolePoint> _holePoints;

		public HolePointService(DataContext dataContext)
		{
			_holePoints = new Repository<HolePoint>(dataContext);
		}

		public async Task<List<GetHolePointDto>> GetAllAsync()
		{
			var list = await _holePoints.GetAllAsync();
			var dtoList = new List<GetHolePointDto>();

			foreach (var item in list)
			{
				dtoList.Add(new GetHolePointDto()
				{
					Id = item.Id,
					X = item.X,
					Y = item.Y,
					Z = item.Z,
					HoleId = item.HoleId
				});
			}

			return dtoList;
		}

		public async Task AddAsync(AddHolePointDto dto)
		{
			var holePoint = new HolePoint()
			{
				X = dto.X,
				Y = dto.Y,
				Z = dto.Z,
				HoleId = dto.HoleId
			};

			await _holePoints.AddAsync(holePoint);
			await _holePoints.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			await _holePoints.DeleteAsync(id);
			await _holePoints.SaveAsync();
		}

		public async Task UpdateAsync(UpdateHolePointDto dto)
		{
			var holePoint = new HolePoint()
			{
				Id = dto.Id,
				X = dto.X,
				Y = dto.Y,
				Z = dto.Z,
				HoleId = dto.HoleId
			};

			_holePoints.Update(holePoint);
			await _holePoints.SaveAsync();
		}
	}
}