using ExpressVoitures.Server.Models.Entities;

namespace ExpressVoitures.Server.Models.Services
{
    public interface IMarqueService
    {
        public Task<IList<Marque>> GetAll();
        public Task<Marque?> GetById(int id);
        public Task<bool> Create(Marque marque);
        public Task<bool> Update(Marque marque);
        public Task<bool> DeleteById(int id);
    }
}
