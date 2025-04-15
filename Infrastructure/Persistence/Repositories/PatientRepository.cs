using Dapper;
using Application.Interfaces;
using Domain.Entities;
using System.Data;

namespace Application.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction; // A ser usado em caso de integração com outras entidades

        public PatientRepository(IDbConnection connection, IDbTransaction transation)
        {
            _connection = connection;
            _transaction = transation;
        }

        public async Task AddAsync(Patient patient)
        {
            var query = @"
                INSERT INTO Patients 
                    (FirstName, LastName, Email, DateOfBirth) 
                VALUES 
                    (@FirstName, @LastName, @Email, @DateOfBirth);";

            await _connection.ExecuteAsync(query, patient);
        }

        public Task AddRangeAsync(IEnumerable<Patient> entities)
        {
            var query = @"
                INSERT INTO Patients 
                    (FirstName, LastName, Email, DateOfBirth) 
                VALUES 
                    (@FirstName, @LastName, @Email, @DateOfBirth);";

            return _connection.ExecuteAsync(query, entities);
        }

        public Task<IEnumerable<Patient>> GetAllAsync()
        {
            var query = "SELECT * FROM Patients";
            return _connection.QueryAsync<Patient>(query);
        }

        public Task<Patient?> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Patients WHERE Id = @Id";

            return _connection.QueryFirstOrDefaultAsync<Patient>(query, new { Id = id });
        }

        public Task UpdateAsync(Patient entity)
        {
            var query = @"
                UPDATE Patients 
                SET 
                    FirstName = @FirstName, 
                    LastName = @LastName, 
                    Email = @Email, 
                    DateOfBirth = @DateOfBirth 
                WHERE Id = @Id;";

            return _connection.ExecuteAsync(query, entity);
        }

        public Task DeleteAsync(int id)
        {
            
            var query = "DELETE FROM Patients WHERE Id = @Id";

            return _connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
