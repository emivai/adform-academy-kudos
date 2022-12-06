using Adform.Academy.Core.Entities;

namespace Adform.Academy.Core.Contracts.Repositories
{
    public interface IKudosRepository
    {
        public Task<KudosEntity?> GetByIdAsync(int id);
        public Task<List<KudosEntity>> GetAsync();
        public Task<int> AddAsync(KudosEntity kudos);

        public Task UpdateAsync(KudosEntity kudos);
    }
}
