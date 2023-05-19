using System.Text.Json.Serialization;

namespace OilWellsWebApiTask.Models
{
	public class Hole
	{
		[JsonIgnore]
		public int Id { get; set; }
		public string Name { get; set; }
		public int Depth { get; set; }

		public int DrillBlockId { get; set; }

		[JsonIgnore]
		public DrillBlock DrillBlock { get; set; }
		[JsonIgnore]
		public virtual List<HolePoints> HolePoints { get; set; }

		public Hole()
		{
			HolePoints = new List<HolePoints>();
		}
	}
}