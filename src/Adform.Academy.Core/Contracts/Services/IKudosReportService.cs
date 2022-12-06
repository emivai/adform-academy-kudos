using Adform.Academy.Core.Entities;

namespace Adform.Academy.Core.Contracts.Services
{
    public interface IKudosReportService
    {
        public Task<KudosReport> GetAsync(DateTime date);
    }
}
