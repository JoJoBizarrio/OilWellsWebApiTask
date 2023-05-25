using AutoMapper;
using OilWellsWebApiTask.Models.Dtos;
using OilWellsWebApiTask.Models;

namespace OilWellsWebApiTask.AutoMapperProfiles
{
	public class HoleMapper : Profile
	{
		public HoleMapper()
		{
			CreateMap<Hole, GetHoleDto>().ReverseMap();
			CreateMap<AddHoleDto, Hole>();
			CreateMap<UpdateHoleDto, Hole>();
		}
	}
}