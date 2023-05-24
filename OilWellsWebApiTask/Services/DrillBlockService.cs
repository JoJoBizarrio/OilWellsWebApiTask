using AutoMapper;
using OilWellsWebApiTask.AutoMapperProfiles;
using OilWellsWebApiTask.Data;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Models.Dtos;
using OilWellsWebApiTask.Repository;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Service
{
	public class DrillBlockService : IDrillBlockService
	{
		private readonly IRepository<DrillBlock> _drillBlocks;
		private readonly IMapper _mapper;

		public DrillBlockService(DataContext dataContext)
		{
			_drillBlocks = new Repository<DrillBlock>(dataContext);
			var config = new MapperConfiguration(cfg => cfg.AddProfile<DrillBlockMapper>());
			_mapper = config.CreateMapper();
		}

		public async Task<ResponseService<List<GetDrillBlockDto>>> GetAllAsync()
		{
			var response = new ResponseService<List<GetDrillBlockDto>>();

			try
			{
				var list = await _drillBlocks.GetAllAsync();
				var dtoList = _mapper.Map<List<GetDrillBlockDto>>(list);

				response.Data = dtoList;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}

		public async Task<ResponseService<List<GetDrillBlockDto>>> AddAsync(AddDrillBlockDto dto)
		{
			var response = new ResponseService<List<GetDrillBlockDto>>();

			var drillBlock = _mapper.Map<DrillBlock>(dto);
			drillBlock.LastUpdateDate = DateTime.UtcNow;

			await _drillBlocks.AddAsync(drillBlock);
			await _drillBlocks.SaveAsync();

			var list = await _drillBlocks.GetAllAsync();
			response.Data = _mapper.Map<List<GetDrillBlockDto>>(list);

			return response;
		}

		public async Task<ResponseService<List<GetDrillBlockDto>>> DeleteAsync(int id)
		{
			var response = new ResponseService<List<GetDrillBlockDto>>();

			try
			{
				var deletedEntity = await _drillBlocks.GetByIdAsync(id);

				if (deletedEntity == null)
				{
					throw new Exception($"Item with id = {id} not found.");
				}

				await _drillBlocks.DeleteAsync(id);
				await _drillBlocks.SaveAsync();

				var list = await _drillBlocks.GetAllAsync();
				response.Data = _mapper.Map<List<GetDrillBlockDto>>(list);
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}

		public async Task<ResponseService<GetDrillBlockDto>> UpdateAsync(UpdateDrillBlockDto dto)
		{
			var response = new ResponseService<GetDrillBlockDto>();

			try
			{
				var updatedItem = await _drillBlocks.GetByIdAsync(dto.Id);

				if (updatedItem == null)
				{
					throw new Exception($"Item with id = {dto.Id} not found.");
				}

				updatedItem.Name = dto.Name;
				updatedItem.LastUpdateDate = DateTime.UtcNow;

				_drillBlocks.Update(updatedItem);
				await _drillBlocks.SaveAsync();

				response.Data = _mapper.Map<GetDrillBlockDto>(updatedItem);
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}
	}
}