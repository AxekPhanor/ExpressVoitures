using ExpressVoitures.Server.Models;
using ExpressVoitures.Server.Models.InputModels;
using ExpressVoitures.Server.Models.OutputModels;
using ExpressVoitures.Server.Repositories;

namespace ExpressVoitures.Server.Services
{
    public class VoitureService : IVoitureService
    {
        private readonly IVoitureRepository voitureRepository;
        public VoitureService(IVoitureRepository voitureRepository)
        {
            this.voitureRepository = voitureRepository;
        }

        public async Task<bool> Create(VoitureInputModel voiture)
        {
            return await voitureRepository.Create(ToVoiture(voiture, 0));
        }

        public async Task<bool> DeleteById(int id)
        {
            return await voitureRepository.DeleteById(id);
        }

        public async Task<IList<VoitureOutputModel>> GetAll()
        {
            List<VoitureOutputModel> voituresOutputModel = [];
            var voitures = await voitureRepository.GetAll();
            foreach (var voiture in voitures)
            {
                voituresOutputModel.Add(ToOutputModel(voiture));
            }
            return voituresOutputModel;
        }

        public async Task<VoitureOutputModel?> GetById(int id)
        {
            var voiture = await voitureRepository.GetById(id);
            if(voiture is not null)
            {
                return ToOutputModel(voiture);
            }
            return null;
        }

        public async Task<bool> Update(VoitureInputModel voiture, int id)
        {
            return await voitureRepository.Update(ToVoiture(voiture, id));
        }

        private VoitureOutputModel ToOutputModel(Voiture voiture)
        {
            return new VoitureOutputModel()
            {
                Id = voiture.Id,
                Marque = voiture.Marque,
                Modele = voiture.Modele,
                Finition = voiture.Finition
            };
        }

        private Voiture ToVoiture(VoitureInputModel voiture, int id)
        {
            return new Voiture()
            {
                Id = id,
                Marque = voiture.Marque,
                Modele = voiture.Modele,
                Finition = voiture.Finition,
                Annee = voiture.Annee
            };
        }
    }
}
