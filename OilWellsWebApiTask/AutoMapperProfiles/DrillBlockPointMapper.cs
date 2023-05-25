using OilWellsWebApiTask.Models.Dtos;
using OilWellsWebApiTask.Models;
using AutoMapper;

namespace OilWellsWebApiTask.AutoMapperProfiles
{
	public class DrillBlockPointMapper : Profile
	{
		public DrillBlockPointMapper()
		{
			CreateMap<DrillBlockPoint, GetDrillBlockPointDto>().ReverseMap();
			CreateMap<AddDrillBlockPointDto, DrillBlockPoint>();
			CreateMap<UpdateDrillBlockPointDto, DrillBlockPoint>();
		}
	}
}