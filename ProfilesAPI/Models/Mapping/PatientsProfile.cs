using AutoMapper;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Models.Mapping;

public class PatientsProfile : Profile
{
    public PatientsProfile()
    {
        CreateMap<PatientDto, Patient>();
        CreateMap<Patient, PatientDto>();
    }
}