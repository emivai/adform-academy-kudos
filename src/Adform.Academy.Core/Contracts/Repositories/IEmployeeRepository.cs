using Adform.Academy.Core.Entities;

namespace Adform.Academy.Core.Contracts.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<Employee?> GetByIdAsync(int id);
        public Task<int> AddAsync(Employee employee);
        public Task<List<Employee>> GetAsync();
    }
}
