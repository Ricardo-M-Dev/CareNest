using Application.Interfaces;

namespace Application.Common.Interfaces
{
    public interface IUnityOfWork : IDisposable
    {
        IPatientRepository Patients { get; }
        IPsychologistRepository Psychologists { get; }
        Task CommitAsync();
        Task RollbackAsync();
    }
}
