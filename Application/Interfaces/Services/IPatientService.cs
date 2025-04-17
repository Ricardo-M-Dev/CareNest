using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IPatientService
    {
        Task<int> SavePatientAsync(Patient entity);
        Task<int> AddPatientAsync(Patient entity);
        Task<Patient?> GetPatientAsync(int id);
        Task<List<Patient?>> GetAllPatientsAsync();
        Task<int> UpdatePatientAsync(Patient entity);
        Task<bool> DeletePatientAsync(int id);
    }
}
