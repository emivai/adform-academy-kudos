using Adform.Academy.Core.Contracts.Repositories;
using Adform.Academy.Core.Contracts.Services;
using Adform.Academy.Core.Entities;
using Adform.Academy.Core.Exceptions;

namespace Adform.Academy.Kudos.Application.Services
{
    public class KudosReportService : IKudosReportService
    {
        private readonly IKudosRepository _kudosRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public KudosReportService(IKudosRepository kudosRepository, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _kudosRepository = kudosRepository;
        }
        public async Task<KudosReport> GetAsync(DateTime date)
        {
            var kudosCount = await _kudosRepository.GetKudosCountAsync(date);

            if(kudosCount == 0)
            {
                throw new NoKudosOnThisDateException(date);
            }

            var mostSent = await _kudosRepository.GetMostKudosSentAsync(date);
            var sender = await _employeeRepository.GetByIdAsync(mostSent.Id);

            var mostReceived = await _kudosRepository.GetMostKudosReceivedAsync(date);
            var receiver = await _employeeRepository.GetByIdAsync(mostReceived.Id);

            var report = new KudosReport
            { 
                SentMostKudos = sender,
                ReceivedMostKudos = receiver,
                KudosCount = kudosCount
            };
            return report;
        }
    }
}
