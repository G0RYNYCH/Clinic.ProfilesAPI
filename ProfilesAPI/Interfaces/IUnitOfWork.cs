namespace ProfilesAPI.Interfaces;

public interface IUnitOfWork
{
    IDoctorsRepository Doctors { get; }
    
    IPatientsRepository Patients { get; }
    
    IReceptionistsRepository Receptionists { get; }
    
    ISpecializationsRepository Specializations { get; }
}