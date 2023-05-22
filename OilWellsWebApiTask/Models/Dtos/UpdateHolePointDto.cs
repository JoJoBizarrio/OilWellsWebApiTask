using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OilWellsWebApiTask.Models.Dtos
{
	public class UpdateHolePointDto
	{
		[Required]
		[ReadOnly(true)]
		[Range(0, int.MaxValue)]
		public int Id { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int Z { get; set; }

		[Required]
		[Range(0, int.MaxValue)]
		public int HoleId { get; set; }
	}
}