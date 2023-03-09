using AutoMapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Services;

public class DoctorsService : ServiceBase<Doctor>, IDoctorsService
{
    public DoctorsService(IDoctorsRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IEnumerable<Doctor>> GetDoctorsByOfficeIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _repository.GetDoctorsByOfficeIdAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<Doctor>> GetDoctorsBySpecializationIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _repository.GetDoctorsBySpecializationIdAsync(id, cancellationToken);
    }

    public async Task CreateAsync(DoctorDto dto, CancellationToken cancellationToken)
    {
        var doctor = _mapper.Map<DoctorDto, Doctor>(dto);
        await _repository.CreateAsync(doctor, cancellationToken);
    }

    public async Task UpdateAsync(DoctorDto dto, CancellationToken cancellationToken)
    {
        var doctor = _mapper.Map<DoctorDto, Doctor>(dto);
        await _repository.UpdateAsync(doctor, cancellationToken);
    }
}