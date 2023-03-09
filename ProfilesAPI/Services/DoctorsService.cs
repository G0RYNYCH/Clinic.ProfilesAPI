using AutoMapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Services;

public class DoctorsService : 
    ServiceBase<Doctor, DoctorDto, IDoctorsRepository>, 
    IDoctorsService
{
    public DoctorsService(IDoctorsRepository repository, IMapper mapper) : 
        base(repository, mapper)
    {
    }

    public async Task<IEnumerable<Doctor>> GetDoctorsByOfficeIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _repositoryBase.GetDoctorsByOfficeIdAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<Doctor>> GetDoctorsBySpecializationIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _repositoryBase.GetDoctorsBySpecializationIdAsync(id, cancellationToken);
    }
    
    public override async Task CreateAsync(DoctorDto dto, CancellationToken cancellationToken)
    {
        var doctor = _mapper.Map<DoctorDto, Doctor>(dto);
        doctor.Id = Guid.NewGuid();
        doctor.SpeciallizationId = Guid.NewGuid();
        doctor.OfficeId = Guid.NewGuid();
        doctor.AccountId = Guid.NewGuid();
        await _repositoryBase.CreateAsync(doctor, cancellationToken);
    }
}