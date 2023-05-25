using AutoMapper;
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
		private readonly IMapper _mapper;

		public HoleService(DataContext dataContext, IMapper mapper)
		{
			_holes = new Repository<Hole>(dataContext);
			_mapper = mapper;
		}

		public async Task<ResponseService<List<GetHoleDto>>> GetAllAsync()
		{
			var response = new ResponseService<List<GetHoleDto>>();

			var list = await _holes.GetAllAsync();
			var dtoList = _mapper.Map<List<GetHoleDto>>(list);

			response.Data = dtoList;

			return response;
		}

		public async Task<ResponseService<List<GetHoleDto>>> AddAsync(AddHoleDto dto)
		{
			var response = new ResponseService<List<GetHoleDto>>();

			try
			{
				var holesList = _holes.Get(
					item => item.DrillBlockId == dto.DrillBlockId,
					null,
					"DrillBlock");

				if (holesList == null)
				{
					throw new Exception($"Drill block with id = {dto.DrillBlockId} not found.");
				}

				var addedItem = _mapper.Map<Hole>(dto);

				await _holes.AddAsync(addedItem);
				await _holes.SaveAsync();
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.ErrorMessage = ex.Message;
			}

			var list = await _holes.GetAllAsync();
			response.Data = _mapper.Map<List<GetHoleDto>>(list);

			return response;
		}

		public async Task<ResponseService<List<GetHoleDto>>> DeleteAsync(int id)
		{
			var response = new ResponseService<List<GetHoleDto>>();

			try
			{
				var deletedItem = await _holes.GetByIdAsync(id);

				if (deletedItem == null)
				{
					throw new Exception($"Item with id = {id} not found.");
				}

				await _holes.DeleteAsync(id);
				await _holes.SaveAsync();
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.ErrorMessage = ex.Message;
			}

			var holesList = await _holes.GetAllAsync();
			response.Data = _mapper.Map<List<GetHoleDto>>(holesList);
			return response;
		}

		public async Task<ResponseService<GetHoleDto>> UpdateAsync(UpdateHoleDto dto)
		{
			var response = new ResponseService<GetHoleDto>();

			try
			{
				var holesList = _holes.Get(item => item.DrillBlockId == dto.DrillBlockId, null, "DrillBlock");

				if (holesList == null)
				{
					throw new Exception($"Drill block with id = {dto.Id} not found.");
				}

				var updatedItem = await _holes.GetByIdAsync(dto.Id);

				if (updatedItem == null)
				{
					throw new Exception($"Item with id = {dto.Id} not found.");
				}

				_mapper.Map(dto, updatedItem);

				_holes.Update(updatedItem);
				await _holes.SaveAsync();

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