using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnityOfWork _uow;

        public PatientService(IUnityOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> SavePatientAsync(Patient entity)
        {
            if (entity.Id == 0)
                return await AddPatientAsync(entity);

            return await UpdatePatientAsync(entity);
        }

        public async Task<int> AddPatientAsync(Patient entity)
        {
            try
            {
                var id = await _uow.Patients.AddAsync(entity);
                await _uow.CommitAsync();

                return id;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new TransactionFailureException($"Adicionar paciente.", "PatientService", ex.InnerException!);
            }
        }
        public async Task<Patient?> GetPatientAsync(int id)
        {
            try
            {
                var patient = await _uow.Patients.GetByIdAsync(id);
                await _uow.CommitAsync();

                return patient;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new TransactionFailureException($"Buscar paciente. Id: {id}.", "PatientService", ex.InnerException!);
            }
        }

        public async Task<List<Patient?>> GetAllPatientsAsync()
        {
            try
            {
                var patients = await _uow.Patients.GetAllAsync();
                await _uow.CommitAsync();

                return patients;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new TransactionFailureException($"Buscar lista de pacientes.", "PatientService", ex.InnerException!);
            }
        }

        public async Task<int> UpdatePatientAsync(Patient patient)
        {
            try
            {
                var id = await _uow.Patients.UpdateAsync(patient);
                await _uow.CommitAsync();

                return id;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new TransactionFailureException($"Atualizar paciente. Id: {patient.Id}.", "PatientService", ex.InnerException!);
            }
        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            try
            {
                var result = await _uow.Patients.DeleteAsync(id);
                await _uow.CommitAsync();

                if (!result)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new TransactionFailureException($"Deletar paciente. Id: {id}.", "PatientService", ex.InnerException!);
            }
        }
    }
}
