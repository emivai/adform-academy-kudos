using Adform.Academy.Core.Contracts.Repositories;
using Adform.Academy.Core.Entities;
using Dapper;
using Npgsql;

namespace Adform.Academy.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly NpgsqlConnection _connection;
        public EmployeeRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> AddAsync(Employee employee)
        {
            var query = @"INSERT INTO employee (name, surname)
                          VALUES (@name, @surname)
                          RETURNING Id";

            return await _connection.QuerySingleAsync<int>(query, new
            {
                name = employee.Name,
                surname = employee.Surname
            });
        }

        public async Task<List<Employee>> GetAsync()
        {
            var query = @"SELECT * FROM employee";
            var employees = await _connection.QueryAsync<Employee>(query);

            return employees.ToList();
        }
    }
}
