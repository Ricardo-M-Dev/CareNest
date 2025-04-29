using Application.Interfaces.Repositories;
using Dapper;
using Domain.Entities;
using System.Data;

namespace Infrastructure.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDbConnection _connection;

        public PersonRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddAsync(Person entity)
        {
            string query = @"
                INSERT INTO Persons 
                    (FirstName, LastName, Email, DateOfBirth) 
                VALUES 
                    (@FirstName, @LastName, @Email, @DateOfBirth);";

            return Convert.ToInt32(await _connection.ExecuteScalarAsync(query, entity));
        }

        public async Task<Person?> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Persons WHERE Id = @Id";

            return await _connection.QueryFirstOrDefaultAsync<Person>(query, new { Id = id });
        }

        public async Task<List<Person?>> GetAllAsync()
        {
            var query = "SELECT * FROM Persons";

            var result = await _connection.QueryAsync<Person?>(query);

            return result.ToList();
        }

        public async Task<int> UpdateAsync(Person entity)
        {
            var query = @"
                UPDATE Persons 
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
            var query = "DELETE FROM Persons WHERE Id = @Id";

            if (await _connection.ExecuteAsync(query, new { Id = id }) == 0)
                return false;

            return true;
        }
    }
}
