using Application.Interfaces.Repositories;

namespace Application.Common.Interfaces
{
    public interface IUnityOfWork : IDisposable
    {
        IPatientRepository Patients { get; }
        IPsychologistRepository Psychologists { get; }
        IPersonRepository Persons { get; }
        Task CommitAsync();
        Task RollbackAsync();
    }
}
