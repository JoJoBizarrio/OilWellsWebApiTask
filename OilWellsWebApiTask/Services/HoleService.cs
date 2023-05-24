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

		public async Task<ResponseService<List<GetHoleDto>>> AddAsync(AddHoleDto dto)
		{
			var addedItem = _mapper.Map<Hole>(dto);

			await _holes.AddAsync(addedItem);
			await _holes.SaveAsync();

			var response = new ResponseService<List<GetHoleDto>>();
			var list = await _holes.GetAllAsync();
			response.Data = _mapper.Map<List<GetHoleDto>>(list);

			return response;
		}

		public async Task<ResponseService<List<GetHoleDto>>> DeleteAsync(int id)
		{
			var response = new ResponseService<List<GetHoleDto>>();

			try
			{
				var deletedEntity = await _holes.GetByIdAsync(id);

				if (deletedEntity == null)
				{
					throw new Exception($"Item with id = {id} not found.");
				}

				await _holes.DeleteAsync(id);
				await _holes.SaveAsync();

				var list = await _holes.GetAllAsync();
				response.Data = _mapper.Map<List<GetHoleDto>>(list);
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}

		public async Task<ResponseService<List<GetHoleDto>>> GetAllAsync()
		{
			var response = new ResponseService<List<GetHoleDto>>();

			var list = await _holes.GetAllAsync();
			var dtoList = _mapper.Map<List<GetHoleDto>>(list);

			response.Data = dtoList;

			return response;
		}

		public async Task<ResponseService<GetHoleDto>> UpdateAsync(UpdateHoleDto dto)
		{
			var response = new ResponseService<GetHoleDto>();

			try
			{
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
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}
	}
}