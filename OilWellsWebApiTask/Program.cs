using Microsoft.EntityFrameworkCore;
using OilWellsWebApiTask.Data;
using OilWellsWebApiTask.Service;
using OilWellsWebApiTask.Service.Abstract;
using System.Text.Json.Serialization;

namespace OilWellsWebApiTask
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
				options.JsonSerializerOptions.WriteIndented = true;
			});

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddScoped<IDrillBlockService, DrillBlockService>();
			builder.Services.AddScoped<IDrillBlockPointService, DrillBlockPointService>();
			builder.Services.AddScoped<IHoleService, HoleService>();
			builder.Services.AddScoped<IHolePointService,  HolePointService>();

			builder.Services.AddDbContext<DataContext>(options =>
				options.UseNpgsql(builder.Configuration.GetConnectionString("OilWellsWebApiTask")));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}