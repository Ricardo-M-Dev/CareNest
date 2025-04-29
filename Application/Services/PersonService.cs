using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnityOfWork _uow;

        public PersonService(IUnityOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> SavePersonAsync(Person entity)
        {
            if (entity.Id == 0)
                return await AddPersonAsync(entity);

            return await UpdatePersonAsync(entity);
        }

        public async Task<int> AddPersonAsync(Person entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                var id = await _uow.Persons.AddAsync(entity);
                await _uow.CommitAsync();

                return id;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new TransactionFailureException($"Adicionar pessoa.", "PersonService", ex.InnerException!);
            }
        }

        public async Task<Person?> GetPersonAsync(int id)
        {
            try
            {
                var person = await _uow.Persons.GetByIdAsync(id);
                await _uow.CommitAsync();

                return person;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new TransactionFailureException($"Adicionar pessoa.", "PersonService", ex.InnerException!);
            }
        }

        public async Task<List<Person?>> GetPersonsAsync()
        {
            try
            {
                var persons = await _uow.Persons.GetAllAsync();
                await _uow.CommitAsync();

                return persons;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new TransactionFailureException($"Adicionar pessoa.", "PersonService", ex.InnerException!);
            }
        }

        public async Task<int> UpdatePersonAsync(Person entity)
        {
            try
            {
                var id = await _uow.Persons.UpdateAsync(entity);
                await _uow.CommitAsync();

                return id;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new TransactionFailureException($"Adicionar pessoa.", "PersonService", ex.InnerException!);
            }
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            try
            {
                if (await _uow.Persons.DeleteAsync(id))
                {
                    await _uow.CommitAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new TransactionFailureException($"Adicionar pessoa.", "PersonService", ex.InnerException!);
            }
        }
    }
}
