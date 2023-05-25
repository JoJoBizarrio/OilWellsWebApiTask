using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OilWellsWebApiTask.Data;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Models.Dtos;
using OilWellsWebApiTask.Repositories;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Service
{
	public class DrillBlockPointService : IDrillBlockPointService
	{
		private readonly UnitOfWork _uow;
		private readonly IMapper _mapper;

		public DrillBlockPointService(DataContext dataContext, IMapper mapper)
		{
			_uow = new UnitOfWork(dataContext);
			_mapper = mapper;
		}

		public async Task<ResponseService<List<GetDrillBlockPointDto>>> GetAllAsync()
		{
			var response = new ResponseService<List<GetDrillBlockPointDto>>();

			var list = await _uow.DrillBlockPoints.GetAllAsync();
			response.Data = _mapper.Map<List<GetDrillBlockPointDto>>(list);

			return response;
		}

		public async Task<ResponseService<List<GetDrillBlockPointDto>>> AddAsync(AddDrillBlockPointDto dto)
		{
			var response = new ResponseService<List<GetDrillBlockPointDto>>();

			try
			{
				var list = _uow.DrillBlocks.GetAll(item => item.DrillBlockPoints);
				var drillBlocks = await list.FirstOrDefaultAsync(item => item.Id == dto.DrillBlockId);

				if (drillBlocks == null)
				{
					throw new Exception($"Drill block with id = {dto.DrillBlockId} not found.");
				}

				if (drillBlocks.DrillBlockPoints.Any(item => item.Sequence == dto.Sequence))
				{
					throw new Exception($"Item with sequence = {dto.Sequence} already exists.");
				}

				var addedItem = _mapper.Map<DrillBlockPoint>(dto);

				await _uow.DrillBlockPoints.AddAsync(addedItem);
				await _uow.DrillBlockPoints.SaveAsync();
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.ErrorMessage = ex.Message;
			}

			var responseList = await _uow.DrillBlockPoints.GetAllAsync();
			response.Data = _mapper.Map<List<GetDrillBlockPointDto>>(responseList);
			return response;
		}

		public async Task<ResponseService<List<GetDrillBlockPointDto>>> DeleteAsync(int id)
		{
			var response = new ResponseService<List<GetDrillBlockPointDto>>();

			try
			{
				var deletedItem = await _uow.DrillBlockPoints.GetByIdAsync(id);

				if (deletedItem == null)
				{
					throw new Exception($"Item with id = {id} not found.");
				}

				await _uow.DrillBlockPoints.DeleteAsync(id);
				await _uow.DrillBlockPoints.SaveAsync();
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.ErrorMessage = ex.Message;
			}

			var responseList = await _uow.DrillBlockPoints.GetAllAsync();
			response.Data = _mapper.Map<List<GetDrillBlockPointDto>>(responseList);
			return response;
		}

		public async Task<ResponseService<GetDrillBlockPointDto>> UpdateAsync(UpdateDrillBlockPointDto dto)
		{
			var response = new ResponseService<GetDrillBlockPointDto>();

			try
			{
				var updatedItem = await _uow.DrillBlockPoints.GetByIdAsync(dto.Id);

				if (updatedItem == null)
				{
					throw new Exception($"Item with id = {dto.Id} not found.");
				}

				var list = _uow.DrillBlocks.GetAll(item => item.DrillBlockPoints);
				var drillBlocks = await list.FirstOrDefaultAsync(item => item.Id == dto.DrillBlockId);

				if (drillBlocks == null)
				{
					throw new Exception($"Drill block with id = {dto.DrillBlockId} not found.");
				}

				if (drillBlocks.DrillBlockPoints.Any(item => item.Sequence == dto.Sequence))
				{
					throw new Exception($"Item with sequence = {dto.Sequence} already exists.");
				}

				_mapper.Map(dto, updatedItem);

				_uow.DrillBlockPoints.Update(updatedItem);
				await _uow.DrillBlockPoints.SaveAsync();

				response.Data = _mapper.Map<GetDrillBlockPointDto>(updatedItem);
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