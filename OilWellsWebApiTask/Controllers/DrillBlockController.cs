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
			return new JsonResult(await _drillBlockService.GetAllAsync());
		}

		[HttpPost("Add")]
		public async Task AddAsync(AddDrillBlockDto dto)
		{
			await _drillBlockService.AddAsync(dto);
		}

		[HttpDelete("Delete/{id:int}")]
		public async Task DeleteAsync(int id)
		{
			await _drillBlockService.DeleteAsync(id);
		}

		[HttpPut("Update")]
		public async Task UpdateAsync(UpdateDrillBlockDto dto)
		{
			await _drillBlockService.UpdateAsync(dto);
		}
	}
}