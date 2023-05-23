using OilWellsWebApiTask.Data;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Models.Dtos;
using OilWellsWebApiTask.Repository;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Service
{
	public class DrillBlockService : IDrillBlockService
	{
		private IRepository<DrillBlock> _drillBlocks;

		public DrillBlockService(DataContext dataContext)
		{
			_drillBlocks = new Repository<DrillBlock>(dataContext);
		}

		public async Task<List<GetDrillBlockDto>> GetAllAsync()
		{
			var list = await _drillBlocks.GetAllAsync();
			var dtoList = new List<GetDrillBlockDto>();

			foreach (var item in list)
			{
				dtoList.Add(new GetDrillBlockDto()
				{
					Id = item.Id,
					Name = item.Name,
					LastUpdateDate = item.LastUpdateDate
				});
			}

			return dtoList;
		}

		public async Task AddAsync(AddDrillBlockDto dto)
		{
			var drillBlock = new DrillBlock()
			{
				Name = dto.Name
			};

			drillBlock.LastUpdateDate = DateTime.UtcNow;

			await _drillBlocks.AddAsync(drillBlock);
			await _drillBlocks.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			await _drillBlocks.DeleteAsync(id);
			await _drillBlocks.SaveAsync();
		}

		public async Task UpdateAsync(UpdateDrillBlockDto dto)
		{
			var drillBlock = new DrillBlock()
			{
				Id = dto.Id,
				Name = dto.Name
			};

			drillBlock.LastUpdateDate = DateTime.UtcNow;

			_drillBlocks.Update(drillBlock);
			await _drillBlocks.SaveAsync();
		}
	}
}