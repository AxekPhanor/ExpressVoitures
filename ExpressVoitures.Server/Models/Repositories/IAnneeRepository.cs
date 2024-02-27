using ExpressVoitures.Server.Models.Entities;

namespace ExpressVoitures.Server.Models.Repositories
{
    public interface IAnneeRepository
    {
        public Task<Annee?> GetById(int id);
        public Task<Annee?> GetByValue(int value);
    }
}
