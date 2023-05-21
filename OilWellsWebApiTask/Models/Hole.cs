using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OilWellsWebApiTask.Models
{
	public class Hole
	{
		public int Id { get; private set; }

		public string Name { get; set; }
		public int Depth { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int DrillBlockId { get; set; }

		public DrillBlock DrillBlock { get; private set; }
		public virtual List<HolePoint> HolePoints { get; private set; }

		public Hole()
		{
			HolePoints = new List<HolePoint>();
		}
	}
}