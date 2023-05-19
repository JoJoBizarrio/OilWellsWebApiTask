using Microsoft.AspNetCore.Mvc;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Service;

namespace OilWellsWebApiTask.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OilWellsController : Controller
	{
		private readonly IOilWellsService _oilWellsService;

		public OilWellsController(IOilWellsService oilWellsService) 
		{
			_oilWellsService = oilWellsService;
		}

		//[HttpGet]
		//public async Task<ActionResult<List<DrillBlock>>> GetAllHeroes()
		//{
		//	return await _oilWellsService.GetAllDrillBlocksAsync();
		//}

		//[HttpPost]
		//public async Task AddDrillBlock(DrillBlock drillBlock)
		//{
		//	await _oilWellsService.AddDrillBlockAsync(drillBlock);
		//}

		[HttpGet]
		public async Task<JsonResult> GetAllDrillBlocks()
		{
			return new JsonResult(await _oilWellsService.GetAllDrillBlocksAsync());
		}

		[HttpPost]
		public async Task AddDrillBlock(DrillBlock drillBlock)
		{
			await _oilWellsService.AddDrillBlockAsync(drillBlock);
		}

		[HttpDelete("{id}")]
		public async Task DeleteDrillBlock(int id)
		{
		}

	}
}