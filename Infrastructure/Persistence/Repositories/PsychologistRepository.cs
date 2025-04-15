using Application.Interfaces;
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
        public Task AddAsync(Psychologist entity)
        {
            var query = @"
                INSERT INTO Psychologists 
                    (FirstName, LastName, Email, DateOfBirth) 
                VALUES 
                    (@FirstName, @LastName, @Email, @DateOfBirth);";

            return _connection.ExecuteAsync(query, entity);
        }

        public Task AddRangeAsync(IEnumerable<Psychologist> entities)
        {
            var query = @"
                INSERT INTO Psychologists 
                    (FirstName, LastName, Email, DateOfBirth) 
                VALUES 
                    (@FirstName, @LastName, @Email, @DateOfBirth);";

            return _connection.ExecuteAsync(query, entities);
        }

        public Task<IEnumerable<Psychologist>> GetAllAsync()
        {
            var query = "SELECT * FROM Psychologists";

            return _connection.QueryAsync<Psychologist>(query);
        }

        public Task<Psychologist?> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Psychologists WHERE Id = @Id";

            return _connection.QueryFirstOrDefaultAsync<Psychologist>(query, new { Id = id });
        }

        public Task UpdateAsync(Psychologist entity)
        {
            var query = @"
                UPDATE Psychologists 
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
            var query = "DELETE FROM Psychologists WHERE Id = @Id;";

            return _connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
