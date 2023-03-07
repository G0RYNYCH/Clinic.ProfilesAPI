using AutoMapper;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Models.Mapping;

public class SpecializationProfile : Profile
{
    protected SpecializationProfile()
    {
        CreateMap<CreateSpecializationDto, Specialization>();
        CreateMap<Specialization, CreateSpecializationDto>();
    }
}