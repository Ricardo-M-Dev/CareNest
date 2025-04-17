using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IPsychologistService
    {
        Task<int> SavePsychologistAsync(Psychologist entity);
        Task<int> AddPsychologistAsync(Psychologist entity);
        Task<Psychologist?> GetPsychologistAsync(int id);
        Task<List<Psychologist?>> GetAllPsychologistsAsync();
        Task<int> UpdatePsychologistAsync(Psychologist entity);
        Task<bool> DeletePsychologistAsync(int id);
    }
}
