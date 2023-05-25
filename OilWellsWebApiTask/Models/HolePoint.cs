﻿namespace OilWellsWebApiTask.Models
{
	public class HolePoint
	{
		public int Id { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int Z { get; set; }

		public int HoleId { get; set; }
		public Hole Hole { get; set; }

		public HolePoint() { }
	}
}