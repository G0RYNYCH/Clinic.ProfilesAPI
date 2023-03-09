using ProfilesAPI.Repositories;

namespace ProfilesAPI.Interfaces;

public interface IUnitOfRepositories<out TContext> where TContext : DbContext, new()
{
    TContext DbContext { get; }
}