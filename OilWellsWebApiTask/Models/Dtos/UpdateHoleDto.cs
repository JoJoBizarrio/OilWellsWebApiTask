using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OilWellsWebApiTask.Models.Dtos
{
	public class UpdateHoleDto
	{
		[Required]
		[ReadOnly(true)]
		[Range(0, int.MaxValue)]
		public int Id { get; set; }
		public string Name { get; set; }
		public int Depth { get; set; }

		[Required]
		[Range(0, int.MaxValue)]
		public int DrillBlockId { get; set; }
	}
}