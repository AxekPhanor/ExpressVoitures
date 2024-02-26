using ExpressVoitures.Server.Models.InputModels;

namespace ExpressVoitures.Server.Models.Services
{
    public interface IAnnonceService
    {
        public Task<IList<AnnonceOutputModel>> GetAll();
        public Task<IList<AnnonceOutputModel>> GetAllAvailable();
        public Task<AnnonceOutputModel?> GetById(int id);
        public Task<bool> Create(AnnonceInputModel annonce);
        public Task<bool> Update(AnnonceInputModel annonce, int id);
        public Task<bool> DeleteById(int id);
        public Task<bool> Sold(int id);
    }
}
