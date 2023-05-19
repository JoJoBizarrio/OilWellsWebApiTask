namespace OilWellsWebApiTask.Models
{
	public class Hole
	{
		public int Id { get; set; }

		public string Name { get; set; }
		public int Depth { get; set; }

		public int DrillBlockId { get; set; }
		public DrillBlock DrillBlock { get; set; }

		public virtual List<HolePoints> HolePoints { get; set; }

		public Hole()
		{
			HolePoints = new List<HolePoints>();
		}
	}
}
