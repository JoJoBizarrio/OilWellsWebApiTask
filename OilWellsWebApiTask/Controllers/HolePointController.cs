using Microsoft.AspNetCore.Mvc;
using OilWellsWebApiTask.Models.Dtos;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Controllers
{
	[ApiController]
	[Route("HolePoints")]
	public class HolePointController : Controller
	{
		private readonly IHolePointService _holePointService;

		public HolePointController(IHolePointService holePointService)
		{
			_holePointService = holePointService;
		}

		[HttpGet("All")]
		public async Task<JsonResult> GetAllAsync()
		{
			return Json(Ok(await _holePointService.GetAllAsync()));
		}

		[HttpPost("Add")]
		public async Task<JsonResult> AddAsync(AddHolePointDto dto)
		{
			return Json(Ok(await _holePointService.AddAsync(dto)));
		}

		[HttpDelete("Delete/{id:int}")]
		public async Task<JsonResult> DeleteAsync(int id)
		{
			var response = await _holePointService.DeleteAsync(id);

			if (response.Data == null)
			{
				return Json(NotFound(response));
			}

			return Json(Ok(response));
		}

		[HttpPut("Update")]
		public async Task<JsonResult> UpdateAsync(UpdateHolePointDto dto)
		{
			var response = await _holePointService.UpdateAsync(dto);

			if (response.Data == null)
			{
				return Json(NotFound(response));
			}

			return Json(Ok(response));
		}
	}
}
