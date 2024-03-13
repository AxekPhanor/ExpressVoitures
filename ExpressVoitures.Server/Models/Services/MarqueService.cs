using ExpressVoitures.Server.Models.Entities;
using ExpressVoitures.Server.Models.InputModels;
using ExpressVoitures.Server.Models.OutputModels;
using ExpressVoitures.Server.Models.Repositories;

namespace ExpressVoitures.Server.Models.Services
{
    public class MarqueService : IMarqueService
    {
        private readonly IMarqueRepository marqueRepository;
        public MarqueService(IMarqueRepository marqueRepository)
        {
            this.marqueRepository = marqueRepository;
        }

        public async Task<IList<Marque>> GetAll()
        {
            return await marqueRepository.GetAll();
        }

        Task<bool> IMarqueService.Create(Marque marque)
        {
            throw new NotImplementedException();
        }

        Task<bool> IMarqueService.DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        Task<Marque?> IMarqueService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IMarqueService.Update(Marque marque)
        {
            throw new NotImplementedException();
        }
    }
}
