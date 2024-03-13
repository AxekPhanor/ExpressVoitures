using ExpressVoitures.Server.Models.Entities;
using ExpressVoitures.Server.Models.InputModels;
using ExpressVoitures.Server.Models.OutputModels;
using ExpressVoitures.Server.Models.Repositories;

namespace ExpressVoitures.Server.Models.Services
{
    public class VoitureEnregistreService : IVoitureEnregistreService
    {
        private readonly IVoitureEnregistreRepository voitureEnregistreRepository;
        public VoitureEnregistreService(IVoitureEnregistreRepository voitureEnregistreRepository)
        {
            this.voitureEnregistreRepository = voitureEnregistreRepository;
        }
        public async Task<bool> Create(VoitureEnregistreInputModel voitureEnregistreInputModel)
        {
            var result = ToVoitureEnregistre(voitureEnregistreInputModel, 0);
            return await voitureEnregistreRepository.Create(result);
        }

        public async Task<bool> DeleteById(int id)
            => await voitureEnregistreRepository.DeleteById(id);

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

        public async Task<bool> Update(VoitureEnregistreInputModel voitureEnregistreInputModel, int id)
        {
            var voitureEnregistre = await voitureEnregistreRepository.GetById(id);
            if (voitureEnregistre == null)
            {
                return false;
            }

            voitureEnregistre.DateAchat = voitureEnregistreInputModel.DateAchat;
            voitureEnregistre.PrixAchat = voitureEnregistreInputModel.PrixAchat;
            voitureEnregistre.Reparations = voitureEnregistreInputModel.Reparations;
            voitureEnregistre.CoutReparations = voitureEnregistreInputModel.CoutReparations;
            voitureEnregistre.VoitureId = voitureEnregistreInputModel.VoitureId;

            return await voitureEnregistreRepository.Update(voitureEnregistre);
        }

        private VoitureEnregistreOutputModel ToOutputModel(VoitureEnregistre voitureEnregistre)
        {
            return new VoitureEnregistreOutputModel()
            {
                Id = voitureEnregistre.Id,
                VoitureId = voitureEnregistre.VoitureId,
                Voiture = voitureEnregistre.Voiture.ToString(),
                DateAchat = voitureEnregistre.DateAchat,
                PrixAchat = voitureEnregistre.PrixAchat,
                Reparations = voitureEnregistre.Reparations,
                CoutReparations = voitureEnregistre.CoutReparations
            };
        }

        private VoitureEnregistre ToVoitureEnregistre(VoitureEnregistreInputModel voitureEnregistreInputModel, int id)
        {
            return new VoitureEnregistre()
            {
                Id = id,
                DateAchat = voitureEnregistreInputModel.DateAchat,
                PrixAchat = voitureEnregistreInputModel.PrixAchat,
                Reparations = voitureEnregistreInputModel.Reparations,
                CoutReparations = voitureEnregistreInputModel.CoutReparations,
                VoitureId = voitureEnregistreInputModel.VoitureId,
            };
        }
    }
}
