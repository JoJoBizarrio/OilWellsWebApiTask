using Microsoft.AspNetCore.Mvc;
using OilWellsWebApiTask.Models.Dtos;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Controllers
{
	[ApiController]
	[Route("DrillBlocks")]
	public class DrillBlockController : Controller
	{
		private readonly IDrillBlockService _drillBlockService;

		public DrillBlockController(IDrillBlockService drillBlockService)
		{
			_drillBlockService = drillBlockService;
		}

		[HttpGet("All")]
		public async Task<JsonResult> GetAllAsync()
		{
			return Json(Ok(await _drillBlockService.GetAllAsync()));
		}

		[HttpPost("Add")]
		public async Task<JsonResult> AddAsync(AddDrillBlockDto dto)
		{
			return Json(Ok(await _drillBlockService.AddAsync(dto)));
		}

		[HttpDelete("Delete/{id:int}")]
		public async Task<JsonResult> DeleteAsync(int id)
		{
			return Json(Ok(await _drillBlockService.DeleteAsync(id)));
		}

		[HttpPut("Update")]
		public async Task<JsonResult> UpdateAsync(UpdateDrillBlockDto dto)
		{
			var response = await _drillBlockService.UpdateAsync(dto);

			if (response.Data == null)
			{
				return Json(NotFound(response));
			}

			return Json(Ok(response));
		}
	}
}