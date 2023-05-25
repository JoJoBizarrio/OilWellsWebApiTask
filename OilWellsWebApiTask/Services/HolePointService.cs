using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OilWellsWebApiTask.Data;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Models.Dtos;
using OilWellsWebApiTask.Repositories;
using OilWellsWebApiTask.Repository;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Service
{
	public class HolePointService : IHolePointService
	{
		private readonly UnitOfWork _uow;
		private readonly IMapper _mapper;

		public HolePointService(DataContext dataContext, IMapper mapper)
		{
			_uow = new UnitOfWork(dataContext);
			_mapper = mapper;
		}

		public async Task<ResponseService<List<GetHolePointDto>>> GetAllAsync()
		{
			var response = new ResponseService<List<GetHolePointDto>>();

			var list = await _uow.HolePoints.GetAllAsync();
			response.Data = _mapper.Map<List<GetHolePointDto>>(list);

			return response;
		}

		public async Task<ResponseService<List<GetHolePointDto>>> AddAsync(AddHolePointDto dto)
		{
			var response = new ResponseService<List<GetHolePointDto>>();

			try
			{
				var holesList = await _uow.Holes.GetAllAsync();
				var hole = holesList.Where(item => item.Id == dto.HoleId);

				if (hole == null)
				{
					throw new Exception($"Hole with id = {dto.HoleId} not found.");
				}

				var addedItem = _mapper.Map<HolePoint>(dto);

				await _uow.HolePoints.AddAsync(addedItem);
				await _uow.HolePoints.SaveAsync();
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.ErrorMessage = ex.Message;
			}

			var list = await _uow.HolePoints.GetAllAsync();
			response.Data = _mapper.Map<List<GetHolePointDto>>(list);

			return response;
		}

		public async Task<ResponseService<List<GetHolePointDto>>> DeleteAsync(int id)
		{
			var response = new ResponseService<List<GetHolePointDto>>();

			try
			{
				var deletedItem = await _uow.HolePoints.GetByIdAsync(id);

				if (deletedItem == null)
				{
					throw new Exception($"Item with id = {id} not found.");
				}

				await _uow.HolePoints.DeleteAsync(id);
				await _uow.HolePoints.SaveAsync();

				var list = await _uow.HolePoints.GetAllAsync();
				response.Data = _mapper.Map<List<GetHolePointDto>>(list);
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.ErrorMessage = ex.Message;
			}

			return response;
		}

		public async Task<ResponseService<GetHolePointDto>> UpdateAsync(UpdateHolePointDto dto)
		{
			var response = new ResponseService<GetHolePointDto>();

			try
			{
				var updatedItem = await _uow.HolePoints.GetByIdAsync(dto.Id);

				if (updatedItem == null)
				{
					throw new Exception($"Item with id = {dto.Id} not found.");
				}

				var holesList = await _uow.Holes.GetAllAsync();
				var hole = holesList.Where(item => item.Id == dto.HoleId);

				if (hole == null)
				{
					throw new Exception($"Hole with id = {dto.HoleId} not found.");
				}

				_mapper.Map(dto, updatedItem);

				_uow.HolePoints.Update(updatedItem);
				await _uow.HolePoints.SaveAsync();

				response.Data = _mapper.Map<GetHolePointDto>(updatedItem);
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