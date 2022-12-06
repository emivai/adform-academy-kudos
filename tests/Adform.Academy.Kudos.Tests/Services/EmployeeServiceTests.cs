using Adform.Academy.Core.Contracts.Repositories;
using Adform.Academy.Core.Entities;
using Adform.Academy.Kudos.Application.Services;
using AutoFixture.NUnit3;
using Moq;

namespace Adform.Academy.Kudos.Tests.Services
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new();
        private EmployeeService _employeeService;

        [SetUp]
        public void Setup()
        {
            _employeeService = new EmployeeService(_employeeRepositoryMock.Object);
        }

        [Test, AutoData]
        public async Task GetAsync_EmployeesExist_ShouldReturnData(Task<List<Employee>> employees)
        {

            _employeeRepositoryMock.Setup(x => x.GetAsync()).Returns(employees);

            var result = await _employeeService.GetAsync();

            Assert.IsNotEmpty(result);
        }
    }
}
