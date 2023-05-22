using Microsoft.AspNetCore.Mvc;
using OilWellsWebApiTask.Models.Dtos;
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
		public async Task<JsonResult> GetAllAsync()
		{
			return new JsonResult(await _holePointService.GetAllAsync());
		}

		[HttpPost("Add")]
		public async Task AddAsync(AddHolePointDto dto)
		{
			await _holePointService.AddAsync(dto);
		}

		[HttpDelete("Delete/{id:int}")]
		public async Task DeleteAsync(int id)
		{
			await _holePointService.DeleteAsync(id);
		}

		[HttpPut("Update")]
		public async Task UpdateAsync(UpdateHolePointDto dto)
		{
			await _holePointService.UpdateAsync(dto);
		}
	}
}
