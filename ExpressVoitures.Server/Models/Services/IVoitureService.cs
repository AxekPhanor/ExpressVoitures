using ExpressVoitures.Server.Models.InputModels;
using ExpressVoitures.Server.Models.OutputModels;

namespace ExpressVoitures.Server.Models.Services
{
    public interface IVoitureService
    {
        public Task<IList<VoitureOutputModel>> GetAll();
        public Task<VoitureOutputModel?> GetById(int id);
        public Task<VoitureOutputModel> Create(VoitureInputModel voiture);
        public Task<bool> Update(VoitureInputModel voiture, int id);
        public Task<bool> DeleteById(int id);
        public Task<IList<VoitureOutputModel>> GetFiltered(string? marque, int? annee, string? modele, string? finition);
        public Task<VoitureOutputModel?> Exist(VoitureInputModel voiture);
    }
}
