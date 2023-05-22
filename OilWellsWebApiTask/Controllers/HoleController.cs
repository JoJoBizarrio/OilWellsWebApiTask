using Microsoft.AspNetCore.Mvc;

namespace OilWellsWebApiTask.Controllers
{
	public class HoleController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
