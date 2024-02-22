using ExpressVoitures.Server.Models.InputModels;
using ExpressVoitures.Server.Models.OutputModels;

namespace ExpressVoitures.Server.Services
{
    public interface IVoitureService
    {
        public Task<IList<VoitureOutputModel>> GetAll();
        public Task<VoitureOutputModel?> GetById(int id);
        public Task<bool> Create(VoitureInputModel voiture);
        public Task<bool> Update(VoitureInputModel voiture, int id);
        public Task<bool> DeleteById(int id);
    }
}
