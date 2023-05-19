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

		[HttpGet("DrillBlocks/All")]
		public async Task<JsonResult> GetAllDrillBlocks()
		{
			return new JsonResult(await _oilWellsService.GetAllDrillBlocksAsync());
		}

		[HttpGet("DrillBlock/{id:int}")]
		public async Task<JsonResult> GetSingleDrillBlock(int id)
		{
			DrillBlock drillBlock = await _oilWellsService.GetSingeDrillBlockAsync(id);

			return new JsonResult(drillBlock);
		}

		[HttpPost("DrillBlock/New")]
		public async Task<JsonResult> AddDrillBlock(DrillBlock drillBlock)
		{
			List<DrillBlock> list = await _oilWellsService.AddDrillBlockAsync(drillBlock);

			return new JsonResult(list);
		}

		[HttpDelete("DrillBlock/Delete/{id:int}")]
		public async Task<JsonResult> DeleteDrillBlock(int id)
		{
			List<DrillBlock> list = await _oilWellsService.DeleteDrillBlockAsync(id);

			return new JsonResult(list);
		}

		[HttpPut("DrillBlock/Update/{id:int}")]
		public async Task<JsonResult> UpdateDrillBlock(int id, DrillBlock drillBlock)
		{
			List<DrillBlock> list = await _oilWellsService.UpdateDrillBlockAsync(id, drillBlock);

			return new JsonResult(list);
		}

		[HttpGet("DrillBlockPoints/All")]
		public async Task<JsonResult> GetAllDrillBlockPointsAsync()
		{
			List<DrillBlockPoint> list = await _oilWellsService.GetAllDrillBlockPointsAsync();

			return new JsonResult(list);
		}

		[HttpGet("DrillBlockPoints/{idDrillBlock:int}")]
		public async Task<JsonResult> GetDrillBlockPointsByDrillBlockAsync(int idDrillBlock)
		{
			List<DrillBlockPoint> list = await _oilWellsService.GetDrillBlockPointsByDrillBlockAsync(idDrillBlock);

			return new JsonResult(list);
		}

		[HttpPost("DrillBlockPoint/New")]
		public async Task<JsonResult> AddDrillBlockPointAsync(DrillBlockPoint drillBlockPoints)
		{
			List<DrillBlockPoint> list = await _oilWellsService.AddDrillBlockPointAsync(drillBlockPoints);

			return new JsonResult(list);
		}

		[HttpDelete("DrillBlockPoint/Delete/{id:int}")]
		public async Task<JsonResult> DeleteDrillBlockPointAsync(int id)
		{
			List<DrillBlockPoint> list = await _oilWellsService.DeleteDrillBlockPointAsync(id);

			return new JsonResult(list);
		}

		[HttpPut("DrillBlockPoint/Update/{id}")]
		public async Task<JsonResult> UpdateDrillBlockPointAsync(int id, DrillBlockPoint drillBlockPoint)
		{
			List<DrillBlockPoint> list = await _oilWellsService.UpdateDrillBlockPointAsync(id, drillBlockPoint);

			return new JsonResult(list);
		}
	}
}