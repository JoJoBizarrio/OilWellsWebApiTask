﻿namespace OilWellsWebApiTask.Models
{
	public class DrillBlockPoint
	{
		public int Id { get; set; }

		public int Sequence { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int Z { get; set; }

		public int DrillBlockId { get; set; }
		public DrillBlock DrillBlock { get; set; }

		public DrillBlockPoint()
		{
		}
	}
}