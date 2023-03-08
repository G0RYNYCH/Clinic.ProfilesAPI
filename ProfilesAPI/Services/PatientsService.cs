using AutoMapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Services;

public class PatientsService : ServiceBase<Patient>, IPatientsService
{
    private readonly IPatientsRepository _repository;
    private readonly IMapper _mapper;

    public PatientsService(IPatientsRepository repository, IMapper mapper) : base(repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task CreateAsync(PatientDto dto, CancellationToken cancellationToken)
    {
        var patient = _mapper.Map<PatientDto, Patient>(dto);
        await _repository.CreateAsync(patient, cancellationToken);
    }

    public async Task UpdateAsync(PatientDto dto, CancellationToken cancellationToken)
    {
        var patient = _mapper.Map<PatientDto, Patient>(dto);
        await _repository.UpdateAsync(patient, cancellationToken);
    }
}