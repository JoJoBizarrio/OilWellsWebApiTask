using Microsoft.AspNetCore.Mvc;
using OilWellsWebApiTask.Models.Dtos;
using OilWellsWebApiTask.Service;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Controllers
{
	[ApiController]
	[Route("Holes")]
	public class HoleController : Controller
	{
		private readonly IHoleService _holeService;

		public HoleController(IHoleService holeService)
		{
			_holeService = holeService;
		}

		[HttpGet("All")]
		public async Task<JsonResult> GetAllAsync()
		{
			return Json(Ok(await _holeService.GetAllAsync()));
		}

		[HttpPost("Add")]
		public async Task<JsonResult> AddAsync(AddHoleDto dto)
		{
			var response = await _holeService.AddAsync(dto);

			if (!response.IsSuccess)
			{
				return Json(NotFound(response));
			}

			return Json(Ok(response));
		}

		[HttpDelete("Delete/{id:int}")]
		public async Task<JsonResult> DeleteAsync(int id)
		{
			var response = await _holeService.DeleteAsync(id);

			if (!response.IsSuccess)
			{
				return Json(NotFound(response));
			}

			return Json(Ok(response));
		}

		[HttpPut("Update")]
		public async Task<JsonResult> UpdateAsync(UpdateHoleDto dto)
		{
			var response = await _holeService.UpdateAsync(dto);

			if (!response.IsSuccess)
			{
				return Json(NotFound(response));
			}

			return Json(Ok(response));
		}
	}
}