using Microsoft.AspNetCore.Mvc;
using OilWellsWebApiTask.Models;
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
		public async Task<JsonResult> GetAll()
		{
			return new JsonResult(await _drillBlockService.GetAllAsync());
		}

		[HttpPost("Add")]
		public async Task AddAsync(DrillBlock drillBlock)
		{
			await _drillBlockService.AddAsync(drillBlock);
		}

		[HttpDelete("Delete/{id:int}")]
		public async Task DeleteDrillBlock(int id)
		{
			await _drillBlockService.DeleteAsync(id);
		}

		[HttpPut("Update")]
		public async Task UpdateDrillBlock(DrillBlock drillBlock)
		{
			await _drillBlockService.UpdateAsync(drillBlock);
		}
	}
}