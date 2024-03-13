using ExpressVoitures.Server.Models.Entities;

namespace ExpressVoitures.Server.Models.Repositories
{
    public interface IFinitionRepository
    {
        public Task<Finition?> GetById(int id);
        public Task<Finition?> GetByName(string name);
        public Task<IList<Finition>> GetAll();
    }
}
