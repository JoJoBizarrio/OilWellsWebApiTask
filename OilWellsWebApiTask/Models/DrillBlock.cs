using System.ComponentModel;
using System.Text.Json.Serialization;

namespace OilWellsWebApiTask.Models
{
	public class DrillBlock
	{
		[JsonIgnore]
		public int Id { get; set; }
		public string Name { get; set; }

		[JsonIgnore]
		public DateTime LastUpdateDate { get; set; }

		[JsonIgnore]
		public virtual List<DrillBlockPoint> DrillBlockPoints { get; set; }

		[JsonIgnore]
		public virtual List<Hole> Holes { get; set; }

		public DrillBlock()
		{
			DrillBlockPoints = new List<DrillBlockPoint>();
			Holes = new List<Hole>();
		}
	}
}