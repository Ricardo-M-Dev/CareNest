using Dapper;
using Domain.Entities;
using System.Data;
using Application.Interfaces.Repositories;

namespace Application.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IDbConnection _connection;

        public PatientRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddAsync(Patient entity)
        {
            var query = @"
                INSERT INTO Patients 
                    (FirstName, LastName, Email, DateOfBirth) 
                VALUES 
                    (@FirstName, @LastName, @Email, @DateOfBirth);";

            return Convert.ToInt32(await _connection.ExecuteScalarAsync(query, entity));
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Patients WHERE Id = @Id";

            return await _connection.QueryFirstOrDefaultAsync<Patient>(query, new { Id = id });
        }

        public async Task<List<Patient?>> GetAllAsync()
        {
            var query = "SELECT * FROM Patients";

            var result = await _connection.QueryAsync<Patient?>(query);

            return result.ToList();
        }

        public async Task<int> UpdateAsync(Patient entity)
        {
            var query = @"
                UPDATE Patients 
                SET 
                    FirstName = @FirstName, 
                    LastName = @LastName, 
                    Email = @Email, 
                    DateOfBirth = @DateOfBirth 
                WHERE Id = @Id;";

            return Convert.ToInt32(await _connection.ExecuteScalarAsync(query, entity));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var query = "DELETE FROM Patients WHERE Id = @Id";

            if (await _connection.ExecuteAsync(query, new { Id = id }) == 0)
                return false;

            return true;
        }
    }
}
