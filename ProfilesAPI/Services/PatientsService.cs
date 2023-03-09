using AutoMapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Services;

public class PatientsService : 
    ServiceBase<Patient, PatientDto, IPatientsRepository>, 
    IPatientsService
{
    public PatientsService(IPatientsRepository repository, IMapper mapper) : 
        base(repository, mapper)
    {
    }
    
    public override async Task CreateAsync(PatientDto dto, CancellationToken cancellationToken)
    {
        var patient = _mapper.Map<PatientDto, Patient>(dto);
        patient.Id = Guid.NewGuid();
        patient.AccountId = Guid.NewGuid();
        await _repositoryBase.CreateAsync(patient, cancellationToken);
    }
}