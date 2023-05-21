using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OilWellsWebApiTask.Models
{
	public class DrillBlockPoint
	{
		public int Id { get; private set; }

		public int Sequence { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int Z { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int DrillBlockId { get; set; }
		public DrillBlock DrillBlock { get; private set; }

		public DrillBlockPoint()
		{
			DrillBlock = new DrillBlock();
		}
	}
}