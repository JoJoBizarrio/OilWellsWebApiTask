using Microsoft.AspNetCore.Mvc;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Service.Abstract;

namespace OilWellsWebApiTask.Controllers
{
	[ApiController]
	[Route("Holes")]
	public class HoleController : Controller
	{
		private readonly IHoleService _holeService;

		public HoleController(IHoleService holeService)
		{
			_holeService = holeService;
		}

		[HttpGet("All")]
		public async Task<JsonResult> GetAll()
		{
			return new JsonResult(await _holeService.GetAllAsync());
		}

		[HttpPost("Add")]
		public async Task AddAsync(Hole hole)
		{
			await _holeService.AddAsync(hole);
		}

		[HttpDelete("Delete/{id:int}")]
		public async Task DeleteDrillBlock(int id)
		{
			await _holeService.DeleteAsync(id);
		}

		[HttpPut("Update")]
		public async Task UpdateDrillBlock(Hole hole)
		{
			await _holeService.UpdateAsync(hole);
		}
	}
}