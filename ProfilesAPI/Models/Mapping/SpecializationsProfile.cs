using AutoMapper;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Models.Mapping;

public class SpecializationsProfile : Profile
{
    public SpecializationsProfile()
    {
        CreateMap<SpecializationDto, Specialization>();
        CreateMap<Specialization, SpecializationDto>();
    }
}