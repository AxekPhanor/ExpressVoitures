using ExpressVoitures.Server.Models.Entities;

namespace ExpressVoitures.Server.Models.Services
{
    public interface IAnneeService
    {
        public Task<IList<Annee>> GetAll();
        public Task<Annee?> GetById(int id);
        public Task<Annee?> GetByValue(int value);
        public Task<bool> Create(Annee annee);
        public Task<bool> Update(Annee annee);
        public Task<bool> DeleteById(int id);
    }
}
