using AutoMapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Services;

public class ReceptionistsService : ServiceBase<Receptionist>, IReceptionistsService
{
    private readonly IReceptionistsRepository _repository;
    private readonly IMapper _mapper;

    public ReceptionistsService(IReceptionistsRepository repository, IMapper mapper) : base(repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task CreateAsync(ReceptionistDto dto, CancellationToken cancellationToken)
    {
        var receptionist = _mapper.Map<ReceptionistDto, Receptionist>(dto);
        receptionist.Id = Guid.NewGuid();
        await _repository.CreateAsync(receptionist, cancellationToken);
    }

    public async Task UpdateAsync(ReceptionistDto dto, CancellationToken cancellationToken)
    {
        var receptionist = _mapper.Map<ReceptionistDto, Receptionist>(dto);
        await _repository.CreateAsync(receptionist, cancellationToken);
    }
}