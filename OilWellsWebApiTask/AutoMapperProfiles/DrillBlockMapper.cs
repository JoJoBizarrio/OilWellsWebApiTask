using AutoMapper;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Models.Dtos;

namespace OilWellsWebApiTask.AutoMapperProfiles
{
    public class DrillBlockMapper : Profile
    {
        public DrillBlockMapper()
        {
            CreateMap<DrillBlock, GetDrillBlockDto>().ReverseMap();
            CreateMap<AddDrillBlockDto, DrillBlock>();
            CreateMap<UpdateDrillBlockDto, DrillBlock>();
        }
    }
}