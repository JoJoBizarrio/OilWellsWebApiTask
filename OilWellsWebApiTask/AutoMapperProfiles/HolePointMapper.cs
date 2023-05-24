using AutoMapper;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Models.Dtos;

namespace OilWellsWebApiTask.AutoMapperProfiles
{
	public class HolePointMapper : Profile
	{
		public HolePointMapper()
		{
			CreateMap<HolePoint, GetHolePointDto>().ReverseMap();
			CreateMap<AddHolePointDto, HolePoint>();
			CreateMap<UpdateHolePointDto, HolePoint>();
		}
	}
}