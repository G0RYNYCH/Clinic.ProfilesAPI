using ProfilesAPI.Interfaces;

namespace ProfilesAPI.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public IDoctorsRepository Doctors { get; }
    
    public IPatientsRepository Patients { get; }
    
    public IReceptionistsRepository Receptionists { get; }
    
    public ISpecializationsRepository Specializations { get; }

    public UnitOfWork(
        IDoctorsRepository doctors, 
        IPatientsRepository patients, 
        IReceptionistsRepository receptionists, 
        ISpecializationsRepository specializations)
    {
        Doctors = doctors;
        Patients = patients;
        Receptionists = receptionists;
        Specializations = specializations;
    }
}