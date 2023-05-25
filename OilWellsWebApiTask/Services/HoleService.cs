using AutoMapper;
using OilWellsWebApiTask.Data;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Models.Dtos;
using OilWellsWebApiTask.Repositories;
using OilWellsWebApiTask.Repository;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Service
{
	public class HoleService : IHoleService
	{
		private readonly UnitOfWork _uow;
		private readonly IMapper _mapper;

		public HoleService(DataContext dataContext, IMapper mapper)
		{
			_uow = new UnitOfWork(dataContext);
			_mapper = mapper;
		}

		public async Task<ResponseService<List<GetHoleDto>>> GetAllAsync()
		{
			var response = new ResponseService<List<GetHoleDto>>();

			var list = await _uow.Holes.GetAllAsync();
			var dtoList = _mapper.Map<List<GetHoleDto>>(list);

			response.Data = dtoList;

			return response;
		}

		public async Task<ResponseService<List<GetHoleDto>>> AddAsync(AddHoleDto dto)
		{
			var response = new ResponseService<List<GetHoleDto>>();

			try
			{
				var drillBlock = await _uow.DrillBlocks.GetByIdAsync(dto.DrillBlockId);

				if (drillBlock == null)
				{
					throw new Exception($"Drill block with id = {dto.DrillBlockId} not found.");
				}

				var addedItem = _mapper.Map<Hole>(dto);

				await _uow.Holes.AddAsync(addedItem);
				await _uow.Holes.SaveAsync();
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.ErrorMessage = ex.Message;
			}

			var list = await _uow.Holes.GetAllAsync();
			response.Data = _mapper.Map<List<GetHoleDto>>(list);

			return response;
		}

		public async Task<ResponseService<List<GetHoleDto>>> DeleteAsync(int id)
		{
			var response = new ResponseService<List<GetHoleDto>>();

			try
			{
				var deletedItem = await _uow.Holes.GetByIdAsync(id);

				if (deletedItem == null)
				{
					throw new Exception($"Item with id = {id} not found.");
				}

				await _uow.Holes.DeleteAsync(id);
				await _uow.Holes.SaveAsync();
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.ErrorMessage = ex.Message;
			}

			var holesList = await _uow.Holes.GetAllAsync();
			response.Data = _mapper.Map<List<GetHoleDto>>(holesList);
			return response;
		}

		public async Task<ResponseService<GetHoleDto>> UpdateAsync(UpdateHoleDto dto)
		{
			var response = new ResponseService<GetHoleDto>();

			try
			{
				var updatedItem = await _uow.Holes.GetByIdAsync(dto.Id);

				if (updatedItem == null)
				{
					throw new Exception($"Item with id = {dto.Id} not found.");
				}

				var list = await _uow.DrillBlocks.GetAllAsync();
				var drillBlock = list.Where(item => item.Id == dto.DrillBlockId);

				if (drillBlock == null)
				{
					throw new Exception($"Drill block with id = {dto.Id} not found.");
				}

				_mapper.Map(dto, updatedItem);

				_uow.Holes.Update(updatedItem);
				await _uow.Holes.SaveAsync();

				response.Data = _mapper.Map<GetHoleDto>(updatedItem);
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