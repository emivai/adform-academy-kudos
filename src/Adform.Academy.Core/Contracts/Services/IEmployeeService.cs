using Adform.Academy.Core.Entities;

namespace Adform.Academy.Core.Contracts.Services
{
    public interface IEmployeeService
    {
        public Task<int> AddAsync(Employee employee);
        public Task<List<Employee>> GetAsync();
    }
}
