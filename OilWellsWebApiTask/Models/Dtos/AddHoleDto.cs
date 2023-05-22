using System.ComponentModel.DataAnnotations;

namespace OilWellsWebApiTask.Models.Dtos
{
	public class AddHoleDto
	{
		public string Name { get; set; }
		public int Depth { get; set; }

		[Required]
		[Range(0, int.MaxValue)]
		public int DrillBlockId { get; set; }
	}
}