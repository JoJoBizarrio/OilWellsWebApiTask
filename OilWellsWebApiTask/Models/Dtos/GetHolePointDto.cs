using System.ComponentModel.DataAnnotations;

namespace OilWellsWebApiTask.Models.Dtos
{
	public class GetHolePointDto
	{
		public int Id { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int Z { get; set; }

		public int HoleId { get; set; }
	}
}
