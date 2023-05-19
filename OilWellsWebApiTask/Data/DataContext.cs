using Microsoft.EntityFrameworkCore;
using OilWellsWebApiTask.Models;

namespace OilWellsWebApiTask.Data
{
	public class DataContext : DbContext
	{
		public DbSet<DrillBlock> DrillBlocks { get; set; }
		public DbSet<DrillBlockPoint> DrillBlockPoints { get; set; }
		public DbSet<Hole> Holes { get; set; }
		public DbSet<HolePoints> HolePoints { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}
	}
}