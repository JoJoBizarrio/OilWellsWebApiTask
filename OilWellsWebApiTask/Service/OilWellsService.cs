using OilWellsWebApiTask.Data;

namespace OilWellsWebApiTask.Service
{
	public class OilWellsService : IOilWellsService
	{
		private readonly DataContext _dataContext;

		public OilWellsService(DataContext dataContext) 
		{
			_dataContext = dataContext;
		}
	}
}