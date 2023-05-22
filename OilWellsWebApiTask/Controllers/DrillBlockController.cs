using Microsoft.AspNetCore.Mvc;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Controllers
{
    [ApiController]
	public class DrillBlockController : Controller
	{
		private readonly IDrillBlockService _drillBlockService;

		public DrillBlockController(IDrillBlockService drillBlockService)
		{
			_drillBlockService = drillBlockService;
		}

		[HttpGet("DrillBlocks/All")]
		public async Task<JsonResult> GetAll()
		{
			return new JsonResult(await _drillBlockService.GetAllAsync());
		}

		[HttpPost("DrillBlocks/Add")]
		public async Task AddAsync(DrillBlock drillBlock)
		{
			await _drillBlockService.AddAsync(drillBlock);
		}

		[HttpDelete("DrillBlock/Delete/{id:int}")]
		public async Task DeleteDrillBlock(int id)
		{
			await _drillBlockService.DeleteAsync(id);
		}

		[HttpPut("DrillBlock/Update/{id:int}")]
		public async Task UpdateDrillBlock(DrillBlock drillBlock)
		{
			 await _drillBlockService.UpdateAsync(drillBlock);
		}
	}
}