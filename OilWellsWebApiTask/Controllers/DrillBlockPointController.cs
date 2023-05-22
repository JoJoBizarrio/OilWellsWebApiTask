using Microsoft.AspNetCore.Mvc;
using OilWellsWebApiTask.Models;
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
		public async Task<JsonResult> GetAll()
		{
			return new JsonResult(await _drillBlockPointService.GetAllAsync());
		}

		[HttpPost("Add")]
		public async Task AddAsync(DrillBlockPoint drillBlockPoint)
		{
			await _drillBlockPointService.AddAsync(drillBlockPoint);
		}

		[HttpDelete("Delete/{id:int}")]
		public async Task DeleteDrillBlock(int id)
		{
			await _drillBlockPointService.DeleteAsync(id);
		}

		[HttpPut("Update")]
		public async Task UpdateDrillBlock(DrillBlockPoint drillBlockPoint)
		{
			await _drillBlockPointService.UpdateAsync(drillBlockPoint);
		}
	}
}