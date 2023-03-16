using AutoMapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Services;

public class DoctorsService : 
    ServiceBase<Doctor, DoctorDto, IDoctorsRepository>, 
    IDoctorsService
{
    private readonly ISpecializationsRepository _specializationsRepository;
    
    public DoctorsService(ISpecializationsRepository specializationsRepository, IDoctorsRepository repository, IMapper mapper) : 
        base(repository, mapper)
    {
        _specializationsRepository = specializationsRepository;
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
        doctor.SpeciallizationId = Guid.NewGuid();// = dto.SpeciallizationId;
        doctor.OfficeId = Guid.NewGuid();//fetch from httpClient 
        doctor.AccountId = Guid.NewGuid();//fetch from httpClient 
        if (!IsSpecializationExists(dto.SpeciallizationId, cancellationToken).Result)
            throw new KeyNotFoundException($"Specialization with Id: {dto.SpeciallizationId} not found");
        await _repositoryBase.CreateAsync(doctor, cancellationToken);
        
        
        
        //add specialization repo
        //duplicate check!!! - I use QuerySingleOrDefaultAsync in my repo, there wont be duplicates
        //check relations with http request
    }

    private async Task<bool> IsSpecializationExists(Guid id, CancellationToken cancellationToken)
    {
        var specialization = await _specializationsRepository.GetByIdAsync(id, cancellationToken);
        if (specialization == null)
            return false;

        return true;
    }
}