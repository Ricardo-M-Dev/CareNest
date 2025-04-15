using Dapper;
using Infrastructure.Persistence;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public PatientRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Patient patient)
        {
            using var connection = _connectionFactory.CreateConnection();

            var query = @"
                INSERT INTO Patients 
                    (FirstName, LastName, Email, DateOfBirth) 
                VALUES 
                    (@FirstName, @LastName, @Email, @DateOfBirth);";

            await connection.ExecuteAsync(query, patient);
        }

        public Task AddRangeAsync(IEnumerable<Patient> entities)
        {
            using var connection = _connectionFactory.CreateConnection();

            var query = @"
                INSERT INTO Patients 
                    (FirstName, LastName, Email, DateOfBirth) 
                VALUES 
                    (@FirstName, @LastName, @Email, @DateOfBirth);";

            return connection.ExecuteAsync(query, entities);
        }

        public Task<IEnumerable<Patient>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            var query = "SELECT * FROM Patients";
            return connection.QueryAsync<Patient>(query);
        }

        public Task<Patient?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();

            var query = "SELECT * FROM Patients WHERE Id = @Id";

            return connection.QueryFirstOrDefaultAsync<Patient>(query, new { Id = id });
        }

        public Task UpdateAsync(Patient entity)
        {
            using var connection = _connectionFactory.CreateConnection();

            var query = @"
                UPDATE Patients 
                SET 
                    FirstName = @FirstName, 
                    LastName = @LastName, 
                    Email = @Email, 
                    DateOfBirth = @DateOfBirth 
                WHERE Id = @Id;";

            return connection.ExecuteAsync(query, entity);
        }

        public Task DeleteAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();

            var query = "DELETE FROM Patients WHERE Id = @Id";

            return connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
