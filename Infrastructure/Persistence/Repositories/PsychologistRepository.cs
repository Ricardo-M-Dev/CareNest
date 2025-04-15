using Application.Interfaces;
using Dapper;
using Domain.Entities;

namespace Infrastructure.Persistence.Repositories
{
    public class PsychologistRepository : IPsychologistRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public PsychologistRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public Task AddAsync(Psychologist entity)
        {
            using var connection = _connectionFactory.CreateConnection();

            var query = @"
                INSERT INTO Psychologists 
                    (FirstName, LastName, Email, DateOfBirth) 
                VALUES 
                    (@FirstName, @LastName, @Email, @DateOfBirth);";

            return connection.ExecuteAsync(query, entity);
        }

        public Task AddRangeAsync(IEnumerable<Psychologist> entities)
        {
            using var connection = _connectionFactory.CreateConnection();

            var query = @"
                INSERT INTO Psychologists 
                    (FirstName, LastName, Email, DateOfBirth) 
                VALUES 
                    (@FirstName, @LastName, @Email, @DateOfBirth);";

            return connection.ExecuteAsync(query, entities);
        }

        public Task<IEnumerable<Psychologist>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            var query = "SELECT * FROM Psychologists";

            return connection.QueryAsync<Psychologist>(query);
        }

        public Task<Psychologist?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();

            var query = "SELECT * FROM Psychologists WHERE Id = @Id";

            return connection.QueryFirstOrDefaultAsync<Psychologist>(query, new { Id = id });
        }

        public Task UpdateAsync(Psychologist entity)
        {
            using var connection = _connectionFactory.CreateConnection();

            var query = @"
                UPDATE Psychologists 
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

            var query = "DELETE FROM Psychologists WHERE Id = @Id;";

            return connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
