using ExpressVoitures.Server.Models.Entities;

namespace ExpressVoitures.Server.Models.Services
{
    public interface IFinitionService
    {
        public Task<IList<Finition>> GetAll();
        public Task<Finition?> GetById(int id);
        public Task<bool> Create(Finition finition);
        public Task<bool> Update(Finition finition);
        public Task<bool> DeleteById(int id);
    }
}
