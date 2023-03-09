using ProfilesAPI.Interfaces;

namespace ProfilesAPI.Repositories;

public class UnitOfRepositories<TContext> : IUnitOfRepositories<TContext> 
    where TContext : DbContext, new()//TODO: ?
{
    private readonly TContext _dbcontext;
    private IRepositoryBase<TContext> _repositoryBase;
    private IDoctorsRepository _doctorsRepository;
    private IPatientsRepository _patientsRepository;
    private IReceptionistsRepository _receptionistsRepository;
    private ISpecializationsRepository _specializationsRepository;

    public UnitOfRepositories()
    {
        _dbcontext = new TContext();
    }

    public TContext DbContext => _dbcontext;

    public IRepositoryBase<TContext> RepositoryBase
    {
        get
        {
            if (_repositoryBase == null)
                _repositoryBase = new ();//TODO: ?

            return _repositoryBase;
        }
    }
    
    public IDoctorsRepository DoctorsRepository
    {
        get
        {
            if (_doctorsRepository == null)
                _doctorsRepository = new DoctorsRepository(_dbcontext);

            return _doctorsRepository;
        }
    }
    
    public IPatientsRepository PatientsRepository
    {
        get
        {
            if (_patientsRepository == null)
                _patientsRepository = new PatientsRepository(_dbcontext);

            return _patientsRepository;
        }
    }
    
    public IReceptionistsRepository ReceptionistsRepository
    {
        get
        {
            if (_receptionistsRepository == null)
                _receptionistsRepository = new ReceptionistsRepository(_dbcontext);

            return _receptionistsRepository;
        }
    }
    
    public ISpecializationsRepository SpecializationsRepository
    {
        get
        {
            if (_specializationsRepository == null)
                _specializationsRepository = new SpecializationsRepository(_dbcontext);

            return _specializationsRepository;
        }
    }
}