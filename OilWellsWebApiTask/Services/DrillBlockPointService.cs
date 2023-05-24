using AutoMapper;
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
		private readonly IMapper _mapper;

		public DrillBlockPointService(DataContext dataContext, IMapper mapper)
		{
			_drillBlockPoints = new Repository<DrillBlockPoint>(dataContext);
			_mapper = mapper;
		}

		public async Task<ResponseService<List<GetDrillBlockPointDto>>> GetAllAsync()
		{
			var response = new ResponseService<List<GetDrillBlockPointDto>>();

			var list = await _drillBlockPoints.GetAllAsync();
			response.Data = _mapper.Map<List<GetDrillBlockPointDto>>(list);

			return response;
		}

		public async Task<ResponseService<List<GetDrillBlockPointDto>>> AddAsync(AddDrillBlockPointDto dto)
		{
			var response = new ResponseService<List<GetDrillBlockPointDto>>();

			try
			{
				var list = _drillBlockPoints.Get(
						item => item.DrillBlockId == dto.DrillBlockId,
						list => list.OrderBy(dbp => dbp.Sequence),
						"DrillBlock");

				if (list == null)
				{
					throw new Exception($"Drill block with id = {dto.DrillBlockId} not found.");
				}

				if (list.Any(item => item.Sequence == dto.Sequence))
				{
					throw new Exception($"Item with sequence = {dto.Sequence} already exists");
				}

				var addedItem = _mapper.Map<DrillBlockPoint>(dto);

				await _drillBlockPoints.AddAsync(addedItem);
				await _drillBlockPoints.SaveAsync();

				list = await _drillBlockPoints.GetAllAsync();
				response.Data = _mapper.Map<List<GetDrillBlockPointDto>>(list);
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}

		public async Task<ResponseService<List<GetDrillBlockPointDto>>> DeleteAsync(int id)
		{
			var response = new ResponseService<List<GetDrillBlockPointDto>>();

			try
			{
				var deletedItem = await _drillBlockPoints.GetByIdAsync(id);

				if (deletedItem == null)
				{
					throw new Exception($"Item with id = {id} not found.");
				}

				await _drillBlockPoints.DeleteAsync(id);
				await _drillBlockPoints.SaveAsync();

				var list = await _drillBlockPoints.GetAllAsync();
				response.Data = _mapper.Map<List<GetDrillBlockPointDto>>(list);
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}

		public async Task<ResponseService<GetDrillBlockPointDto>> UpdateAsync(UpdateDrillBlockPointDto dto)
		{
			var response = new ResponseService<GetDrillBlockPointDto>();

			try
			{
				var updatedItem = await _drillBlockPoints.GetByIdAsync(dto.Id);

				if (updatedItem == null)
				{
					throw new Exception($"Item with id = {dto.Id} not found.");
				}

				var list = _drillBlockPoints.Get(
						item => item.DrillBlockId == dto.DrillBlockId,
						list => list.OrderBy(dbp => dbp.Sequence),
						"DrillBlock");

				if (list == null)
				{
					throw new Exception($"Item DrillBlock with id = {dto.DrillBlockId} not found.");
				}

				if (list.Any(item => item.Sequence == dto.Sequence))
				{
					throw new Exception($"Item with sequence = {dto.Sequence} already exists.");
				}

				_mapper.Map(dto, updatedItem);

				_drillBlockPoints.Update(updatedItem);
				await _drillBlockPoints.SaveAsync();
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