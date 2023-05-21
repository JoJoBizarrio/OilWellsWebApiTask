using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OilWellsWebApiTask.Models
{
	public class HolePoint
	{
		public int Id { get; private set; }

		public int X { get; set; }
		public int Y { get; set; }
		public int Z { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int HoleId { get; set; }
		public Hole Hole { get; private set; }

		public HolePoint() { }
	}
}