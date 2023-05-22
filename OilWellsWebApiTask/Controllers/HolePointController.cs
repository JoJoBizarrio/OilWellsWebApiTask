using Microsoft.AspNetCore.Mvc;
using OilWellsWebApiTask.Models;
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
		public async Task<JsonResult> GetAll()
		{
			return new JsonResult(await _holePointService.GetAllAsync());
		}

		[HttpPost("Add")]
		public async Task AddAsync(HolePoint holePoint)
		{
			await _holePointService.AddAsync(holePoint);
		}

		[HttpDelete("Delete/{id:int}")]
		public async Task DeleteDrillBlock(int id)
		{
			await _holePointService.DeleteAsync(id);
		}

		[HttpPut("Update")]
		public async Task UpdateDrillBlock(HolePoint holePoint)
		{
			await _holePointService.UpdateAsync(holePoint);
		}
	}
}
