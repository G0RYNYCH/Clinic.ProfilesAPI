using AutoMapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Services;

public abstract class ServiceBase<T, TDto> : IServiceBase<T>
{
    protected readonly IRepositoryBase<T> _repositoryBase;
    protected readonly IMapper _mapper;

    protected ServiceBase(IRepositoryBase<T> repositoryBase, IMapper mapper)
    {
        _repositoryBase = repositoryBase;
        _mapper = mapper;
    }

    public async Task<IEnumerable<T>> GetAllAsync(PaginationDto dto, CancellationToken cancellationToken)
    {
        return await _repositoryBase.GetAllAsync(dto, cancellationToken);
    }
    
    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _repositoryBase.GetByIdAsync(id, cancellationToken);
    }
    
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _repositoryBase.DeleteAsync(id, cancellationToken);
    }
    
    public async Task CreateAsync(TDto dto, CancellationToken cancellationToken)
    {
        var doctor = _mapper.Map<TDto, T>(dto);
        await _repository.CreateAsync(doctor, cancellationToken);
    }

    public async Task UpdateAsync(DoctorDto dto, CancellationToken cancellationToken)
    {
        var doctor = _mapper.Map<DoctorDto, Doctor>(dto);
        await _repository.UpdateAsync(doctor, cancellationToken);
    }
}