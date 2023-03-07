using AutoMapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Services;

public class SpecializationService : ISpecializationService
{
    private readonly ISpecializationRepository _repository;
    private readonly IMapper _mapper;

    public SpecializationService(ISpecializationRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task CreateAsync(CreateSpecializationDto specializationDto, CancellationToken cancellationToken)
    {
        var specialization = _mapper.Map<CreateSpecializationDto, Specialization>(specializationDto);
        await _repository.CreateAsync(specialization, cancellationToken);
    }
}