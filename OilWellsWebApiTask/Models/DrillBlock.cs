namespace OilWellsWebApiTask.Models
{
	public class DrillBlock
	{
		public int Id { get; private set; }
		public string Name { get; set; }
		public DateTime LastUpdateDate { get; set; }

		public virtual List<DrillBlockPoint> DrillBlockPoints { get; private set; }
		public virtual List<Hole> Holes { get; private set; }

		public DrillBlock()
		{
			DrillBlockPoints = new List<DrillBlockPoint>();
			Holes = new List<Hole>();
		}
	}
}