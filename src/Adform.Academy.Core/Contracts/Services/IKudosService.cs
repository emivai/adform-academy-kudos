using Adform.Academy.Core.Entities;

namespace Adform.Academy.Core.Contracts.Services
{
    public interface IKudosService
    {
        public Task<KudosEntity?> GetByIdAsync(int id);
        public Task<List<KudosEntity>> GetAsync();
        public Task<int> AddAsync(KudosEntity kudos,int senderId, int recieverId);

        public Task UpdateAsync(int id);
    }
}
