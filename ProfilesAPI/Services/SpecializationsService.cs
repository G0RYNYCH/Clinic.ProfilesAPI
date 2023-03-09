using AutoMapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Services;

public class SpecializationsService : 
    ServiceBase<Specialization, SpecializationDto, ISpecializationsRepository>, 
    ISpecializationsService
{
    public SpecializationsService(ISpecializationsRepository repository, IMapper mapper) : 
        base(repository, mapper)
    {
    }
    
    public override async Task CreateAsync(SpecializationDto dto, CancellationToken cancellationToken)
    {
        var specialization = _mapper.Map<SpecializationDto, Specialization>(dto);
        specialization.Id = Guid.NewGuid();
        await _repositoryBase.CreateAsync(specialization, cancellationToken);
    }
}