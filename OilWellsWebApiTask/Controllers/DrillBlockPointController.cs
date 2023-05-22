using Microsoft.AspNetCore.Mvc;
using OilWellsWebApiTask.Models.Dtos;
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
		public async Task<JsonResult> GetAllAsync()
		{
			return new JsonResult(await _drillBlockPointService.GetAllAsync());
		}

		[HttpPost("Add")]
		public async Task AddAsync(AddDrillBlockPointDto dto)
		{
			await _drillBlockPointService.AddAsync(dto);
		}

		[HttpDelete("Delete/{id:int}")]
		public async Task DeleteAsync(int id)
		{
			await _drillBlockPointService.DeleteAsync(id);
		}

		[HttpPut("Update")]
		public async Task UpdateAsync(UpdateDrillBlockPointDto dto)
		{
			await _drillBlockPointService.UpdateAsync(dto);
		}
	}
}