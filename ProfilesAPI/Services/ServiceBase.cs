using ProfilesAPI.Interfaces;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Services;

public abstract class ServiceBase<T> : IServiceBase<T>
{
    private readonly IRepositoryBase<T> _repositoryBase;

    protected ServiceBase(IRepositoryBase<T> repositoryBase)
    {
        _repositoryBase = repositoryBase;
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
}