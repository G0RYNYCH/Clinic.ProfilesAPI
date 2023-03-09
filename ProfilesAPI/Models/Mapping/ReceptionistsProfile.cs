using AutoMapper;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Models.Mapping;

public class ReceptionistsProfile : Profile
{
    public ReceptionistsProfile()
    {
        CreateMap<ReceptionistDto, Receptionist>();
        CreateMap<Receptionist, ReceptionistDto>();
    }
}