using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class PsychologistService : IPsychologistService
    {
        private readonly IUnityOfWork _uow;

        public PsychologistService(IUnityOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> SavePsychologistAsync(Psychologist entity)
        {
            if (entity.Id == 0)
                return await AddPsychologistAsync(entity);

            return await UpdatePsychologistAsync(entity);
        }

        public async Task<int> AddPsychologistAsync(Psychologist entity)
        {
            try
            {
                var id = await _uow.Psychologists.AddAsync(entity);
                await _uow.CommitAsync();

                return id;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new TransactionFailureException($"Adicionar psicólogo.", "PsychologistService", ex.InnerException!);
            }
        }

        public async Task<Psychologist?> GetPsychologistAsync(int id)
        {
            try
            {
                var psychologist = await _uow.Psychologists.GetByIdAsync(id);
                await _uow.CommitAsync();

                return psychologist;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new TransactionFailureException($"Buscar psicólogo. Id: {id}.", "PsychologistService", ex.InnerException!);
            }
        }

        public async Task<List<Psychologist?>> GetAllPsychologistsAsync()
        {
            try
            {
                var psychologists = await _uow.Psychologists.GetAllAsync();
                await _uow.CommitAsync();

                return psychologists;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new TransactionFailureException($"Buscar lista de psicólogos.", "PsychologistService", ex.InnerException!);
            }
        }

        public async Task<int> UpdatePsychologistAsync(Psychologist entity)
        {
            try
            {
                var id = await _uow.Psychologists.UpdateAsync(entity);
                await _uow.CommitAsync();

                return id;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new TransactionFailureException($"Atualizar psicólogo. Id: {entity.Id}.", "PsychologistService", ex.InnerException!);
            }
        }

        public async Task<bool> DeletePsychologistAsync(int id)
        {
            try
            {
                var result = await _uow.Psychologists.DeleteAsync(id);
                await _uow.CommitAsync();

                if (!result)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new TransactionFailureException($"Deletar psicólogo. Id: {id}.", "PsychologistService", ex.InnerException!);
            }
        }
    }
}
