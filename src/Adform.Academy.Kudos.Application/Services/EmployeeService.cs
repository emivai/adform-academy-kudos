using Adform.Academy.Core.Contracts.Repositories;
using Adform.Academy.Core.Contracts.Services;
using Adform.Academy.Core.Entities;

namespace Adform.Academy.Kudos.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<int> AddAsync(Employee employee)
        {
            var id = await _employeeRepository.AddAsync(employee);
            return id;
        }

        public async Task<List<Employee>> GetAsync()
        {
            var employees = await _employeeRepository.GetAsync();
            return employees;
        }
    }
}
