using AutoMapper;
using LMWebApi.Common.Models.Database;
using LMWebApi.Common.Models.DTOs;

namespace LMWebApi.Common.Mappers.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DailyNutritionDTO, DailyNutrition>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id));
            CreateMap<DailyNutrition, DailyNutritionDTO>();
        }
    }
}