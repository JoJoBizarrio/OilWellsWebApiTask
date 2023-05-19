using Microsoft.AspNetCore.Mvc;
using OilWellsWebApiTask.Service;

namespace OilWellsWebApiTask.Controllers
{
	public class OilWellsController : Controller
	{
		private readonly IOilWellsService _oilWellsService;

		public OilWellsController(IOilWellsService oilWellsService) 
		{
			_oilWellsService = oilWellsService;
		}


	}
}