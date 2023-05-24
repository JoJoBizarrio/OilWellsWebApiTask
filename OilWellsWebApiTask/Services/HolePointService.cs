using AutoMapper;
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
		private readonly IMapper _mapper;

		public HolePointService(DataContext dataContext, IMapper mapper)
		{
			_holePoints = new Repository<HolePoint>(dataContext);
			_mapper = mapper;
		}

		public async Task<ResponseService<List<GetHolePointDto>>> GetAllAsync()
		{
			var response = new ResponseService<List<GetHolePointDto>>();

			var list = await _holePoints.GetAllAsync();
			response.Data = _mapper.Map<List<GetHolePointDto>>(list);

			return response;
		}

		public async Task<ResponseService<List<GetHolePointDto>>> AddAsync(AddHolePointDto dto)
		{
			var addedItem = _mapper.Map<HolePoint>(dto);

			await _holePoints.AddAsync(addedItem);
			await _holePoints.SaveAsync();

			var response = new ResponseService<List<GetHolePointDto>>();
			var list = await _holePoints.GetAllAsync();
			response.Data = _mapper.Map<List<GetHolePointDto>>(list);

			return response;
		}

		public async Task<ResponseService<List<GetHolePointDto>>> DeleteAsync(int id)
		{
			var response = new ResponseService<List<GetHolePointDto>>();

			try
			{
				var deletedEntity = await _holePoints.GetByIdAsync(id);

				if (deletedEntity == null)
				{
					throw new Exception($"Item with id = {id} not found.");
				}

				await _holePoints.DeleteAsync(id);
				await _holePoints.SaveAsync();

				var list = await _holePoints.GetAllAsync();
				response.Data = _mapper.Map<List<GetHolePointDto>>(list);
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}

		public async Task<ResponseService<GetHolePointDto>> UpdateAsync(UpdateHolePointDto dto)
		{
			var response = new ResponseService<GetHolePointDto>();

			try
			{
				var updatedItem = await _holePoints.GetByIdAsync(dto.Id);

				if (updatedItem == null)
				{
					throw new Exception($"Item with id = {dto.Id} not found.");
				}

				_mapper.Map(dto, updatedItem);

				_holePoints.Update(updatedItem);
				await _holePoints.SaveAsync();

				response.Data = _mapper.Map<GetHolePointDto>(updatedItem);
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