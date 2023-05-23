using Microsoft.AspNetCore.Mvc;
using OilWellsWebApiTask.Models.Dtos;
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
		public async Task<JsonResult> GetAllAsync()
		{
			return new JsonResult(await _holeService.GetAllAsync());
		}

		[HttpPost("Add")]
		public async Task AddAsync(AddHoleDto dto)
		{
			await _holeService.AddAsync(dto);
		}

		[HttpDelete("Delete/{id:int}")]
		public async Task DeleteAsync(int id)
		{
			await _holeService.DeleteAsync(id);
		}

		[HttpPut("Update")]
		public async Task UpdateAsync(UpdateHoleDto dto)
		{
			await _holeService.UpdateAsync(dto);
		}
	}
}