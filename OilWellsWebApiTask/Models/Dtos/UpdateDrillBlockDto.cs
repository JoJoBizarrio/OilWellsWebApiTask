using System.ComponentModel.DataAnnotations;

namespace OilWellsWebApiTask.Models.Dtos
{
	public class UpdateDrillBlockDto
	{
		[Required]
		public int Id { get; set; }
		[Required]
		[MinLength(1)]
		[MaxLength(20)]
		public string Name { get; set; }
	}
}