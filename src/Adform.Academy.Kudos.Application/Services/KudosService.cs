using Adform.Academy.Core.Contracts.Repositories;
using Adform.Academy.Core.Contracts.Services;
using Adform.Academy.Core.Entities;
using Adform.Academy.Core.Exceptions;

namespace Adform.Academy.Kudos.Application.Services
{
    public class KudosService : IKudosService
    {
        private readonly IKudosRepository _kudosRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public KudosService(IKudosRepository kudosRepository, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _kudosRepository = kudosRepository;
        }

        public async Task<int> AddAsync(KudosEntity kudos, int senderId, int receiverId)
        {
            if(senderId == receiverId)
            {
                throw new SenderAndReceiverCantBeEqualException(receiverId);
            }

            var sender = await _employeeRepository.GetByIdAsync(senderId);
            var receiver = await _employeeRepository.GetByIdAsync(receiverId);

            if (sender == null)
            {
                throw new EmployeeNotFoundException(senderId);
            }
            else if(receiver == null)
            {
                throw new EmployeeNotFoundException(receiverId);
            }

            kudos.Sender.Id = senderId;
            kudos.Receiver.Id = receiverId;

            var id = await _kudosRepository.AddAsync(kudos);
            return id;
        }

        public async Task<List<KudosEntity>> GetAsync()
        {
            var kudos = await _kudosRepository.GetAsync();
            return kudos;
        }

        public async Task<KudosEntity?> GetByIdAsync(int id)
        {
            var kudos = await _kudosRepository.GetByIdAsync(id);

            if (kudos == null)
            {
                throw new KudosNotFoundException(id);
            }

            return kudos;
        }

        public async Task UpdateAsync(int id)
        {
            var kudos = await _kudosRepository.GetByIdAsync(id);

            if (kudos == null)
            {
                throw new KudosNotFoundException(id);
            }

            kudos.Exchanged = true;

            await _kudosRepository.UpdateAsync(kudos);
        }
    }
}
