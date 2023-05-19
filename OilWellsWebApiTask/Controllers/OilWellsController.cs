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

		[HttpGet]
		public async Task<JsonResult> GetAllDrillBlocks()
		{
			return new JsonResult(await _oilWellsService.GetAllDrillBlocksAsync());
		}

		[HttpGet("{id}", Name = "SingleDrillBlock")]
		public async Task<JsonResult> GetSingleDrillBlock(int id)
		{
			DrillBlock drillBlock = await _oilWellsService.GetSingeDrillBlockAsync(id);

			return new JsonResult(drillBlock);
		}

		[HttpPost]
		public async Task<JsonResult> AddDrillBlock(DrillBlock drillBlock)
		{
			List<DrillBlock> list = await _oilWellsService.AddDrillBlockAsync(drillBlock);

			return new JsonResult(list);
		}

		[HttpDelete("{id}")]
		public async Task<JsonResult> DeleteDrillBlock(int id)
		{
			List<DrillBlock> list = await _oilWellsService.DeleteDrillBlockAsync(id);

			return new JsonResult(list);
		}

		[HttpPut("{id}")]
		public async Task<JsonResult> UpdateDrillBlock(int id, DrillBlock drillBlock)
		{
			List<DrillBlock> list = await _oilWellsService.UpdateDrillBlockAsync(id, drillBlock);

			return new JsonResult(list);
		}
	}
}