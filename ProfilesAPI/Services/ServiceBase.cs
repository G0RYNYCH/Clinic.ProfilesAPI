using AutoMapper;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Services;

public abstract class ServiceBase<T, TDto, TRepository> : IServiceBase<T> where TRepository : IRepositoryBase<T>
{
    protected TRepository _repositoryBase;
    protected readonly IMapper _mapper;

    protected ServiceBase(TRepository repositoryBase, IMapper mapper)
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
    
    public virtual async Task CreateAsync(TDto dto, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TDto, T>(dto);
        await _repositoryBase.CreateAsync(entity, cancellationToken);
    }
    
    public async Task UpdateAsync(TDto dto, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TDto, T>(dto);
        await _repositoryBase.UpdateAsync(entity, cancellationToken);
    }
    
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _repositoryBase.DeleteAsync(id, cancellationToken);
    }
}