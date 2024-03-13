using ExpressVoitures.Server.Models.InputModels;
using ExpressVoitures.Server.Models.OutputModels;

namespace ExpressVoitures.Server.Models.Services
{
    public interface IVoitureEnregistreService
    {
        public Task<IList<VoitureEnregistreOutputModel>> GetAll();
        public Task<VoitureEnregistreOutputModel?> GetById(int id);
        public Task<bool> Create(VoitureEnregistreInputModel voitureEnregistreInputModel);
        public Task<bool> Update(VoitureEnregistreInputModel voitureEnregistreInputModel, int id);
        public Task<bool> DeleteById(int id);
    }
}
