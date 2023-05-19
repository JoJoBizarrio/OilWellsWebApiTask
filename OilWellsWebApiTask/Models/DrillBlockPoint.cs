using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OilWellsWebApiTask.Models
{
	public class DrillBlockPoint
	{
		[JsonIgnore]
		public int Id { get; set; }

		public int Sequence { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int Z { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int DrillBlockId { get; set; }

		[JsonIgnore]
		public DrillBlock DrillBlock { get; set; }

		public DrillBlockPoint()
		{
			DrillBlock = new DrillBlock();
		}
	}
}