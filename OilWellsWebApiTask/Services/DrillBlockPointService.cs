using OilWellsWebApiTask.Data;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Models.Dtos;
using OilWellsWebApiTask.Repository;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Service
{
	public class DrillBlockPointService : IDrillBlockPointService
	{
		private readonly IRepository<DrillBlockPoint> _drillBlockPoints;

		public DrillBlockPointService(DataContext dataContext)
		{
			_drillBlockPoints = new Repository<DrillBlockPoint>(dataContext);
		}

		public async Task<List<GetDrillBlockPointDto>> GetAllAsync()
		{
			var list = await _drillBlockPoints.GetAllAsync();
			var dtoList = new List<GetDrillBlockPointDto>();

			foreach (var item in list)
			{
				dtoList.Add(new GetDrillBlockPointDto()
				{
					Id = item.Id,
					Sequence = item.Sequence,
					X = item.X,
					Y = item.Y,
					Z = item.Z,
					DrillBlockId = item.DrillBlockId
				});
			}

			return dtoList;
		}

		public async Task AddAsync(AddDrillBlockPointDto dto)
		{
			var drillBlockPoint = new DrillBlockPoint()
			{
				Sequence = dto.Sequence,
				X = dto.X,
				Y = dto.Y,
				Z = dto.Z,
				DrillBlockId = dto.DrillBlockId
			};

			await _drillBlockPoints.AddAsync(drillBlockPoint);
			await _drillBlockPoints.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			await _drillBlockPoints.DeleteAsync(id);
			await _drillBlockPoints.SaveAsync();
		}

		public async Task UpdateAsync(UpdateDrillBlockPointDto dto)
		{
			var drillBlockPoint = new DrillBlockPoint()
			{
				Id = dto.Id,
				Sequence = dto.Sequence,
				X = dto.X,
				Y = dto.Y,
				Z = dto.Z,
				DrillBlockId = dto.DrillBlockId
			};

			_drillBlockPoints.Update(drillBlockPoint);
			await _drillBlockPoints.SaveAsync();
		}
	}
}