using ExpressVoitures.Server.Models.Entities;

namespace ExpressVoitures.Server.Models.Services
{
    public interface IModeleService
    {
        public Task<IList<Modele>> GetAll();
    }
}
