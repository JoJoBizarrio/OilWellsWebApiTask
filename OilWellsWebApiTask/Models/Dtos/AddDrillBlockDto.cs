using System.ComponentModel.DataAnnotations;

namespace OilWellsWebApiTask.Models.Dtos
{
	public class AddDrillBlockDto
	{
		[Required]
		[MinLength(1)]
		[MaxLength(100)]
		public string Name { get; set; }
	}
}