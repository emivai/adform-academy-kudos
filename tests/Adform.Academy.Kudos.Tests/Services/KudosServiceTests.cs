using Adform.Academy.Core.Contracts.Repositories;
using Adform.Academy.Core.Entities;
using Adform.Academy.Core.Exceptions;
using Adform.Academy.Kudos.Application.Services;
using AutoFixture.NUnit3;
using Moq;

namespace Adform.Academy.Kudos.Tests.Services
{
    public class KudosServiceTests
    {
        private readonly Mock<IKudosRepository> _kudosRepositoryMock = new();
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new();
        private KudosService _kudosService;

        [SetUp]
        public void Setup()
        {
            _kudosService = new KudosService(_kudosRepositoryMock.Object, _employeeRepositoryMock.Object);
        }

        [Test, AutoData]
        public async Task AddAsync_ExistingEmployeeIds_ShouldReturnId(KudosEntity kudos, Task<Employee> employee1, Task<Employee> employee2)
        {

            _employeeRepositoryMock.Setup(x => x.GetByIdAsync(1)).Returns(employee1);
            _employeeRepositoryMock.Setup(x => x.GetByIdAsync(2)).Returns(employee2);

            var result = await _kudosService.AddAsync(kudos, 1, 2);

            Assert.NotNull(result);
        }

        [Test, AutoData]
        public async Task AddAsync_EqualEmployeeIds_ShouldThrowSenderAndReceiverCantBeEqualException(KudosEntity kudos)
        {
            var ex = Assert.ThrowsAsync<SenderAndReceiverCantBeEqualException>(async () => await _kudosService.AddAsync(kudos, 1, 1));

            Assert.That(ex.Message, Is.EqualTo($"Sender and receiver id is equal to: {1}.They cannot be the same!"));
        }

        [Test, AutoData]
        public async Task AddAsync_NonExistantEmployeeIds_ShouldThrowEmployeeNotFoundException(KudosEntity kudos, Employee employee1)
        {
            _employeeRepositoryMock.Setup(x => x.GetByIdAsync(10)).ReturnsAsync(value:null);
            _employeeRepositoryMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(employee1);

            var ex = Assert.ThrowsAsync<EmployeeNotFoundException>(async () => await _kudosService.AddAsync(kudos, 10, 1));

            Assert.That(ex.Message, Is.EqualTo($"Employee with id: {10} was not found!"));
        }

        [Test, AutoData]
        public async Task GetByIdAsync_IdExists_ShouldReturn(KudosEntity kudos)
        {
            _kudosRepositoryMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(kudos);

            var result = await _kudosService.GetByIdAsync(1);

            Assert.That(result, Is.EqualTo(kudos));
        }

        [Test, AutoData]
        public async Task GetByIdAsync_IdDoesNotExist_ShouldThrowKudosNotFoundException(KudosEntity kudos)
        {
            _kudosRepositoryMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(value: null);

            var ex = Assert.ThrowsAsync<KudosNotFoundException>(async () => await _kudosService.GetByIdAsync(1));

            Assert.That(ex.Message, Is.EqualTo($"Kudos with id: {1} was not found!"));
        }

        [Test, AutoData]
        public async Task UpdateAsync_IdDoesNotExist_ShouldThrowKudosNotFoundException(KudosEntity kudos)
        {
            _kudosRepositoryMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(value: null);

            var ex = Assert.ThrowsAsync<KudosNotFoundException>(async () => await _kudosService.UpdateAsync(1));

            Assert.That(ex.Message, Is.EqualTo($"Kudos with id: {1} was not found!"));
        }

        [Test, AutoData]
        public async Task UpdateAsync_IdDoesExist_ShouldUpdateExchangedToTrue(KudosEntity kudos)
        {
            kudos.Exchanged = false;
            _kudosRepositoryMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(kudos);

            await _kudosService.UpdateAsync(1);

            Assert.That(kudos.Exchanged, Is.EqualTo(true));
        }
    }
}
