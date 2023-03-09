using AutoMapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Services;

public class ReceptionistsService : 
    ServiceBase<Receptionist, ReceptionistDto, IReceptionistsRepository>, 
    IReceptionistsService
{
    public ReceptionistsService(IReceptionistsRepository repository, IMapper mapper) : 
        base(repository, mapper)
    {
    }
    
    public override async Task CreateAsync(ReceptionistDto dto, CancellationToken cancellationToken)
    {
        var receptionist = _mapper.Map<ReceptionistDto, Receptionist>(dto);
        receptionist.Id = Guid.NewGuid();
        receptionist.OfficeId = Guid.NewGuid();
        receptionist.AccountId = Guid.NewGuid();
        await _repositoryBase.CreateAsync(receptionist, cancellationToken);
    }
}