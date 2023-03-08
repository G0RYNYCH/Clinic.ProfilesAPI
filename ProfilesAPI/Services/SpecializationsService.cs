using AutoMapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Services;

public class SpecializationsService : ServiceBase<Specialization>, ISpecializationsService
{
    //private readonly IUnitOfWork _unitOfWork;
    private readonly ISpecializationsRepository _repository;
    private readonly IMapper _mapper;

    public SpecializationsService(ISpecializationsRepository repository, IMapper mapper) : base(repository)
    {
        //_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task CreateAsync(SpecializationDto dto, CancellationToken cancellationToken)
    {
        var specialization = _mapper.Map<SpecializationDto, Specialization>(dto);
        specialization.Id = Guid.NewGuid();
        await _repository.CreateAsync(specialization, cancellationToken);
    }

    public async Task UpdateAsync(SpecializationDto dto, CancellationToken cancellationToken)
    {
        var specialization = _mapper.Map<SpecializationDto, Specialization>(dto);
        await _repository.UpdateAsync(specialization, cancellationToken);
    }
}