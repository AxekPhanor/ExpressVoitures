using ExpressVoitures.Server.Models.Entities;

namespace ExpressVoitures.Server.Models.Repositories
{
    public interface IVoitureEnregistreRepository
    {
        public Task<IList<VoitureEnregistre>> GetAll();
        public Task<VoitureEnregistre?> GetById(int id);
        public Task<VoitureEnregistre> Create(VoitureEnregistre voiture);
        public Task<bool> Update(VoitureEnregistre voiture);
        public Task<bool> DeleteById(int id);
        public Task<bool> CheckVoitureExists(int voitureId);
    }
}
