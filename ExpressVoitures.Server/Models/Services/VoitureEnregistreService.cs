using ExpressVoitures.Server.Models.Entities;
using ExpressVoitures.Server.Models.InputModels;
using ExpressVoitures.Server.Models.OutputModels;
using ExpressVoitures.Server.Models.Repositories;

namespace ExpressVoitures.Server.Models.Services
{
    public class VoitureEnregistreService : IVoitureEnregistreService
    {
        private readonly IVoitureEnregistreRepository voitureEnregistreRepository;
        private readonly IVoitureRepository voitureRepository;
        public VoitureEnregistreService(IVoitureEnregistreRepository voitureEnregistreRepository, IVoitureRepository voitureRepository)
        {
            this.voitureEnregistreRepository = voitureEnregistreRepository;
            this.voitureRepository = voitureRepository;
        }
        public async Task<bool> Create(VoitureEnregistreInputModel voitureEnregistre)
        {
            var result = await ToVoitureEnregistre(voitureEnregistre, 0);
            if (result is not null)
            {
                return await voitureEnregistreRepository.Create(result);
            }
            return false;
        }

        public async Task<bool> DeleteById(int id)
        {
            return await voitureEnregistreRepository.DeleteById(id);
        }

        public async Task<IList<VoitureEnregistreOutputModel>> GetAll()
        {
            List<VoitureEnregistreOutputModel> voituresEnregistreOutputModel = [];
            var voituresEnregistre = await voitureEnregistreRepository.GetAll();
            foreach (var voitureEnregistre in voituresEnregistre)
            {
                voituresEnregistreOutputModel.Add(ToOutputModel(voitureEnregistre));
            }
            return voituresEnregistreOutputModel;
        }

        public async Task<VoitureEnregistreOutputModel?> GetById(int id)
        {
            var result = await voitureEnregistreRepository.GetById(id);
            if (result is not null)
            {
                return ToOutputModel(result);
            }
            return null;
        }

        public async Task<bool> Update(VoitureEnregistreInputModel voitureEnregistre, int id)
        {
            var result = await ToVoitureEnregistre(voitureEnregistre, id);
            if (result is not null)
            {
                return await voitureEnregistreRepository.Update(result);
            }
            return false;
            
        }

        private VoitureEnregistreOutputModel ToOutputModel(VoitureEnregistre voitureEnregistre)
        {
            return new VoitureEnregistreOutputModel()
            {
                Id = voitureEnregistre.Id,
                VoitureId = voitureEnregistre.VoitureId,
                DateAchat = voitureEnregistre.DateAchat,
                PrixAchat = voitureEnregistre.PrixAchat,
                Reparations = voitureEnregistre.Reparations,
                CoutReparations = voitureEnregistre.CoutReparations
            };
        }

        private async Task<VoitureEnregistre?> ToVoitureEnregistre(VoitureEnregistreInputModel voitureEnregistreInputModel, int id)
        {
            var voiture = await voitureRepository.GetById(voitureEnregistreInputModel.VoitureId);
            if (voiture is not null)
            {
                var voitureEnregistre = new VoitureEnregistre()
                {
                    Id = id,
                    DateAchat = voitureEnregistreInputModel.DateAchat,
                    PrixAchat = voitureEnregistreInputModel.PrixAchat,
                    Reparations = voitureEnregistreInputModel.Reparations,
                    CoutReparations = voitureEnregistreInputModel.CoutReparations,
                    VoitureId = voitureEnregistreInputModel.VoitureId,
                    Voiture = voiture
                };
                return voitureEnregistre;
            }
            return null;
        }
    }
}
