using ExpressVoitures.Server.Models.Entities;
using ExpressVoitures.Server.Models.Repositories;

namespace ExpressVoitures.Server.Models.Services
{
    public class AnneeService : IAnneeService
    {
        private readonly IAnneeRepository anneeRepository;
        public AnneeService(IAnneeRepository anneeRepository)
        {
            this.anneeRepository = anneeRepository;
        }
        public Task<bool> Create(Annee annee)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Annee>> GetAll()
        {
            return await anneeRepository.GetAll();
        }

        public Task<Annee?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Annee?> GetByValue(int value)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Annee annee)
        {
            throw new NotImplementedException();
        }
    }
}
