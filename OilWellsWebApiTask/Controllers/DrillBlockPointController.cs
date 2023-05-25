using Microsoft.AspNetCore.Mvc;
using OilWellsWebApiTask.Models.Dtos;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Controllers
{
	[ApiController]
	[Route("DrillBlockPoints")]
	public class DrillBlockPointController : Controller
	{
		private readonly IDrillBlockPointService _drillBlockPointService;

		public DrillBlockPointController(IDrillBlockPointService drillBlockService)
		{
			_drillBlockPointService = drillBlockService;
		}

		[HttpGet("All")]
		public async Task<JsonResult> GetAllAsync()
		{
			return Json(Ok(await _drillBlockPointService.GetAllAsync()));
		}

		[HttpPost("Add")]
		public async Task<JsonResult> AddAsync(AddDrillBlockPointDto dto)
		{
			var response = await _drillBlockPointService.AddAsync(dto);

			if (!response.IsSuccess)
			{
				return Json(NotFound(response));
			}

			return Json(Ok(response));
		}

		[HttpDelete("Delete/{id:int}")]
		public async Task<JsonResult> DeleteAsync(int id)
		{
			var response = await _drillBlockPointService.DeleteAsync(id);

			if (response.Data == null)
			{
				return Json(NotFound(response));
			}

			return Json(Ok(response));
		}

		[HttpPut("Update")]
		public async Task<JsonResult> UpdateAsync(UpdateDrillBlockPointDto dto)
		{
			var response = await _drillBlockPointService.UpdateAsync(dto);

			if (response.Data == null)
			{
				return Json(NotFound(response));
			}

			return Json(Ok(response));
		}
	}
}