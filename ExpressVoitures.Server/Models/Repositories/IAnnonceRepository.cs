using ExpressVoitures.Server.Models.Entities;

namespace ExpressVoitures.Server.Models.Repositories
{
    public interface IAnnonceRepository
    {
        public Task<IList<Annonce>> GetAll();
        public Task<IList<Annonce>> GetAllAvailable();
        public Task<Annonce?> GetById(int id);
        public Task<Annonce?> GetByIdAvailable(int id);
        public Task<bool> Create(Annonce annonce);
        public Task<bool> Update(Annonce annonce);
        public Task<bool> DeleteById(int id);
        public Task<bool> CheckVoitureEnregistreExists(int voitureEnregistreId);
    }
}
