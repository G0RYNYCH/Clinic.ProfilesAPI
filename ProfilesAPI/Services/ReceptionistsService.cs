using AutoMapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Services;

public class ReceptionistsService : IReceptionistsService
{
    private readonly IReceptionistsRepository _repository;
    private readonly IMapper _mapper;

    public ReceptionistsService(IReceptionistsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<IEnumerable<Receptionist>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Receptionist> GetById(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(CreateReceptionistDto receptionistDto, CancellationToken cancellationToken)
    {
        var receptionist = _mapper.Map<CreateReceptionistDto, Receptionist>(receptionistDto);
        receptionist.Id = Guid.NewGuid();
        await _repository.CreateAsync(receptionist, cancellationToken);
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}