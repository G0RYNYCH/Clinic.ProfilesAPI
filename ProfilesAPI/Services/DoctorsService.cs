using AutoMapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Services;

public class DoctorsService : ServiceBase<Doctor>, IDoctorsService
{
    private readonly IDoctorsRepository _repository;
    private readonly IMapper _mapper;

    public DoctorsService(IDoctorsRepository repository, IMapper mapper) : base(repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Doctor>> GetDoctorsByOfficeId(Guid id, CancellationToken cancellationToken)
    {
        return await _repository.GetDoctorsByOfficeId(id, cancellationToken);
    }

    public async Task<IEnumerable<Doctor>> GetDoctorsBySpecializationId(Guid id, CancellationToken cancellationToken)
    {
        return await _repository.GetDoctorsBySpecializationId(id, cancellationToken);
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