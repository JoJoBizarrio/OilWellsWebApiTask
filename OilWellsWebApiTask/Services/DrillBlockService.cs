using AutoMapper;
using OilWellsWebApiTask.Data;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Models.Dtos;
using OilWellsWebApiTask.Repositories;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Service
{
	public class DrillBlockService : IDrillBlockService
	{
		private readonly UnitOfWork _uow;
		private readonly IMapper _mapper;

		public DrillBlockService(DataContext dataContext, IMapper mapper)
		{
			_uow = new UnitOfWork(dataContext);
			_mapper = mapper;
		}

		public async Task<ResponseService<List<GetDrillBlockDto>>> GetAllAsync()
		{
			var response = new ResponseService<List<GetDrillBlockDto>>();

			var list = await _uow.DrillBlocks.GetAllAsync();
			var dtoList = _mapper.Map<List<GetDrillBlockDto>>(list);

			response.Data = dtoList;

			return response;
		}

		public async Task<ResponseService<List<GetDrillBlockDto>>> AddAsync(AddDrillBlockDto dto)
		{
			var response = new ResponseService<List<GetDrillBlockDto>>();

			var addedItem = _mapper.Map<DrillBlock>(dto);
			addedItem.LastUpdateDate = DateTime.UtcNow;

			await _uow.DrillBlocks.AddAsync(addedItem);
			await _uow.DrillBlocks.SaveAsync();

			var responseList = await _uow.DrillBlocks.GetAllAsync();
			response.Data = _mapper.Map<List<GetDrillBlockDto>>(responseList);

			return response;
		}

		public async Task<ResponseService<List<GetDrillBlockDto>>> DeleteAsync(int id)
		{
			var response = new ResponseService<List<GetDrillBlockDto>>();

			try
			{
				var deletedItem = await _uow.DrillBlocks.GetByIdAsync(id);

				if (deletedItem == null)
				{
					throw new Exception($"Item with id = {id} not found.");
				}

				await _uow.DrillBlocks.DeleteAsync(id);
				await _uow.DrillBlocks.SaveAsync();
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.ErrorMessage = ex.Message;
			}

			var responseList = await _uow.DrillBlocks.GetAllAsync();
			response.Data = _mapper.Map<List<GetDrillBlockDto>>(responseList);
			return response;
		}

		public async Task<ResponseService<GetDrillBlockDto>> UpdateAsync(UpdateDrillBlockDto dto)
		{
			var response = new ResponseService<GetDrillBlockDto>();

			try
			{
				var updatedItem = await _uow.DrillBlocks.GetByIdAsync(dto.Id);

				if (updatedItem == null)
				{
					throw new Exception($"Item with id = {dto.Id} not found.");
				}

				_mapper.Map(dto, updatedItem);

				updatedItem.LastUpdateDate = DateTime.UtcNow;

				_uow.DrillBlocks.Update(updatedItem);
				await _uow.DrillBlocks.SaveAsync();

				response.Data = _mapper.Map<GetDrillBlockDto>(updatedItem);
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.ErrorMessage = ex.Message;
			}

			return response;
		}
	}
}