
using ExpressVoitures.Server.Models.Entities;
using ExpressVoitures.Server.Models.Repositories;

namespace ExpressVoitures.Server.Models.Services
{
    public class FinitionService : IFinitionService
    {
        private readonly IFinitionRepository finitionRepository;
        public FinitionService(IFinitionRepository finitionRepository)
        {
            this.finitionRepository = finitionRepository;
        }
        public Task<bool> Create(Finition finition)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Finition>> GetAll()
        {
            return await finitionRepository.GetAll();
        }

        public Task<Finition?> GetById(int id)
        {
            throw new NotImplementedException();
        }


        public Task<bool> Update(Finition finition)
        {
            throw new NotImplementedException();
        }
    }
}
