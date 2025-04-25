using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IPersonService
    {
        Task<int> SavePersonAsync(Person entity);
        Task<int> AddPersonAsync(Person entity);
        Task<Person?> GetPersonAsync(int id);
        Task<List<Person?>> GetPersonsAsync();
        Task<int> UpdatePersonAsync(Person entity);
        Task<bool> DeletePersonAsync(int id);
    }
}
