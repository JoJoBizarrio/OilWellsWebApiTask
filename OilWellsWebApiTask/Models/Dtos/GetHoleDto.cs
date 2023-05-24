
namespace OilWellsWebApiTask.Models.Dtos
{
	public class GetHoleDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Depth { get; set; }

		public int DrillBlockId { get; set; }
	}
}