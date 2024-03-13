using ExpressVoitures.Server.Models.Entities;

namespace ExpressVoitures.Server.Models.Repositories
{
    public interface IMarqueRepository
    {
        public Task<Marque?> GetById(int id);
        public Task<Marque?> GetByName(string name);
        public Task<IList<Marque>> GetAll();
    }
}
