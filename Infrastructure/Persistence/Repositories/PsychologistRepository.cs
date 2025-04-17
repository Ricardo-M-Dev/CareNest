using Application.Interfaces.Repositories;
using Dapper;
using Domain.Entities;
using System.Data;

namespace Infrastructure.Persistence.Repositories
{
    public class PsychologistRepository : IPsychologistRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction; // A ser usado em caso de integração com outras entidades

        public PsychologistRepository(IDbConnection connection, IDbTransaction transation)
        {
            _connection = connection;
            _transaction = transation;
        }
        public async Task<int> AddAsync(Psychologist entity)
        {
            var query = @"
                INSERT INTO Psychologists 
                    (FirstName, LastName, Email, DateOfBirth) 
                VALUES 
                    (@FirstName, @LastName, @Email, @DateOfBirth);";

            return Convert.ToInt32(await _connection.ExecuteScalarAsync(query, entity));
        }

        public async Task<Psychologist?> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Psychologists WHERE Id = @Id";

            return await _connection.QueryFirstOrDefaultAsync<Psychologist>(query, new { Id = id });
        }

        public async Task<List<Psychologist?>> GetAllAsync()
        {
            var query = "SELECT * FROM Psychologists";

            var result = await _connection.QueryAsync<Psychologist?>(query);

            return result.ToList();
        }

        public async Task<int> UpdateAsync(Psychologist entity)
        {
            var query = @"
                UPDATE Psychologists 
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
            var query = "DELETE FROM Psychologists WHERE Id = @Id;";

            if (await _connection.ExecuteAsync(query, new { Id = id }) == 0)
                return false;

            return true;
        }
    }
}
