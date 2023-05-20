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

			if (drillBlock == null) 
			{
				return new JsonResult(new NotFoundResult());
			};

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

			if (list == null)
			{
				return new JsonResult(new NotFoundResult());
			};

			return new JsonResult(list);
		}

		[HttpPut("DrillBlock/Update/{id:int}")]
		public async Task<JsonResult> UpdateDrillBlock(int id, DrillBlock drillBlock)
		{
			List<DrillBlock> list = await _oilWellsService.UpdateDrillBlockAsync(id, drillBlock);

			if (list == null)
			{
				return new JsonResult(new NotFoundResult());
			};

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

			if (list == null)
			{
				return new JsonResult(new NotFoundResult());
			};

			return new JsonResult(list);
		}

		[HttpPost("DrillBlockPoint/New")]
		public async Task<JsonResult> AddDrillBlockPointAsync(DrillBlockPoint drillBlockPoints)
		{
			List<DrillBlockPoint> list = await _oilWellsService.AddDrillBlockPointAsync(drillBlockPoints);

			if (list == null)
			{
				return new JsonResult(new NotFoundResult());
			};

			return new JsonResult(list);
		}

		[HttpDelete("DrillBlockPoint/Delete/{id:int}")]
		public async Task<JsonResult> DeleteDrillBlockPointAsync(int id)
		{
			List<DrillBlockPoint> list = await _oilWellsService.DeleteDrillBlockPointAsync(id);

			if (list == null)
			{
				return new JsonResult(new NotFoundResult());
			};

			return new JsonResult(list);
		}

		[HttpPut("DrillBlockPoint/Update/{id}")]
		public async Task<JsonResult> UpdateDrillBlockPointAsync(int id, DrillBlockPoint drillBlockPoint)
		{
			List<DrillBlockPoint> list = await _oilWellsService.UpdateDrillBlockPointAsync(id, drillBlockPoint);

			if (list == null)
			{
				return new JsonResult(new NotFoundResult());
			};

			return new JsonResult(list);
		}

		[HttpGet("Holes/All")]
		public async Task<JsonResult> GetAllHolesAsync()
		{
			return new JsonResult(await _oilWellsService.GetAllHolesAsync());
		}

		[HttpGet("Holes/{idDrillBlock}")]
		public async Task<JsonResult> GetHolesByDrillBlockAsync(int idDrillBlock)
		{
			List<Hole> list = await _oilWellsService.GetHolesByDrillBlockAsync(idDrillBlock);

			if (list == null)
			{
				return new JsonResult(new NotFoundResult());
			};

			return new JsonResult(list);
		}

		[HttpPost("Holes/New")]
		public async Task<JsonResult> AddHoleAsync(Hole hole)
		{
			List<Hole> list = await _oilWellsService.AddHoleAsync(hole);

			if (list == null)
			{
				return new JsonResult(new NotFoundResult());
			};

			return new JsonResult(list);
		}

		[HttpDelete("Holes/Delete/{id}")]
		public async Task<JsonResult> DeleteHoleAsync(int id)
		{
			List<Hole> list = await _oilWellsService.DeleteHoleAsync(id);

			if (list == null)
			{
				return new JsonResult(new NotFoundResult());
			};

			return new JsonResult(list);
		}

		[HttpPut("Holes/Update/{id}")]
		public async Task<JsonResult> UpdateHoleAsync(int id, Hole request)
		{
			List<Hole> list = await _oilWellsService.UpdateHoleAsync(id, request);

			if (list == null)
			{
				return new JsonResult(new NotFoundResult());
			};

			return new JsonResult(list);
		}

		[HttpGet("HolePoints/All")]
		public async Task<JsonResult> GetAllHolePointsAsync()
		{
			return new JsonResult(await _oilWellsService.GetAllHolePointsAsync());
		}

		[HttpPost("HolePoints/New")]
		public async Task<JsonResult> AddHolePointAsync(HolePoint holePoint)
		{
			List<HolePoint> list = await _oilWellsService.AddHolePointAsync(holePoint);

			if (list == null)
			{
				return new JsonResult(new NotFoundResult());
			};

			return new JsonResult(list);
		}

		[HttpDelete("HolePoints/Delete/{id:int}")]
		public async Task<JsonResult> DeleteHolePointAsync(int id)
		{
			List<HolePoint> list = await _oilWellsService.DeleteHolePointAsync(id);

			if (list == null)
			{
				return new JsonResult(new NotFoundResult());
			};

			return new JsonResult(list);
		}

		[HttpPut("HolePoints/Update/{id}")]
		public async Task<JsonResult> UpdateHolePointAsync(int id, HolePoint request)
		{
			List<HolePoint> list = await _oilWellsService.UpdateHolePointAsync(id, request);

			if (list == null)
			{
				return new JsonResult(new NotFoundResult());
			};

			return new JsonResult(list);
		}
	}
}