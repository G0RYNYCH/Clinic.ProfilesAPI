using AutoMapper;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Models.Mapping;

public class DoctorsProfile : Profile
{
    public DoctorsProfile()
    {
        CreateMap<DoctorDto, Doctor>();
        CreateMap<Doctor, DoctorDto>();
    }
}