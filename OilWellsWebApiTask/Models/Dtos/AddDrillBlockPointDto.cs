using System.ComponentModel.DataAnnotations;

namespace OilWellsWebApiTask.Models.Dtos
{
	public class AddDrillBlockPointDto
	{
		[Required]
		[Range(0, int.MaxValue)]
		public int Sequence { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int Z { get; set; }

		[Required]
		[Range(0, int.MaxValue)]
		public int DrillBlockId { get; set; }
	}
}