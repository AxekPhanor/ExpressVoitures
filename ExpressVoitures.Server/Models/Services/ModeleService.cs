using ExpressVoitures.Server.Models.Entities;
using ExpressVoitures.Server.Models.Repositories;

namespace ExpressVoitures.Server.Models.Services
{
    public class ModeleService : IModeleService
    {
        private readonly IModeleRepository modeleRepository;
        public ModeleService(IModeleRepository modeleRepository)
        {
            this.modeleRepository = modeleRepository;
        }
        public async Task<IList<Modele>> GetAll()
            => await modeleRepository.GetAll();
    }
}
