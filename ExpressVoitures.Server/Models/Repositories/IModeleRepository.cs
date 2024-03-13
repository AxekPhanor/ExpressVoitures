using ExpressVoitures.Server.Models.Entities;

namespace ExpressVoitures.Server.Models.Repositories
{
    public interface IModeleRepository
    {
        public Task<Modele?> GetById(int id);
        public Task<Modele?> GetByName(string name);
        public Task<IList<Modele>> GetAll();
    }
}
