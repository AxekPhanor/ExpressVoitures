using ExpressVoitures.Server.Models.Entities;
using ExpressVoitures.Server.Models.InputModels;
using ExpressVoitures.Server.Models.OutputModels;
using ExpressVoitures.Server.Models.Repositories;

namespace ExpressVoitures.Server.Models.Services
{
    public class VoitureService : IVoitureService
    {
        private readonly IVoitureRepository voitureRepository;
        private readonly IMarqueRepository marqueRepository;
        private readonly IAnneeRepository anneeRepository;
        private readonly IModeleRepository modeleRepository;
        private readonly IFinitionRepository finitionRepository;
        public VoitureService(
            IVoitureRepository voitureRepository,
            IMarqueRepository marqueRepository,
            IAnneeRepository anneeRepository,
            IModeleRepository modeleRepository,
            IFinitionRepository finitionRepository)
        {
            this.voitureRepository = voitureRepository;
            this.marqueRepository = marqueRepository;
            this.anneeRepository = anneeRepository;
            this.modeleRepository = modeleRepository;
            this.finitionRepository = finitionRepository;
        }

        public async Task<bool> Create(VoitureInputModel voiture)
        {
            var marque = await marqueRepository.GetByName(voiture.Marque);
            var modele = await modeleRepository.GetByName(voiture.Modele);
            var finition = await finitionRepository.GetByName(voiture.Finition);
            var annee = await anneeRepository.GetByValue(voiture.Annee);
            if (marque is null)
            {
                marque = new Marque() { Nom = voiture.Marque };
            }
            if (modele is null)
            {
                modele = new Modele() { Nom = voiture.Modele };
            }
            if (finition is null)
            {
                finition = new Finition() { Nom = voiture.Finition };
            }
            if (annee is null)
            {
                annee = new Annee() { Valeur = voiture.Annee };
            }
            var newVoiture = new Voiture()
            {
                MarqueId = marque.Id,
                ModeleId = modele.Id,
                FinitionId = finition.Id,
                AnneeId = annee.Id,
                Marque = marque,
                Modele = modele,
                Finition = finition,
                Annee = annee
            };
            return await voitureRepository.Create(newVoiture);
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
                var result = await ToOutputModel(voiture);
                if(result is not null)
                {
                    voituresOutputModel.Add(result);
                }
            }
            return voituresOutputModel;
        }

        public async Task<VoitureOutputModel?> GetById(int id)
        {
            var voiture = await voitureRepository.GetById(id);
            if (voiture is null)
            {
                return null;
            }
            var result = await ToOutputModel(voiture);
            if(result is null)
            {
                return null;
            }
            return result;
        }

        public async Task<bool> Update(VoitureInputModel voiture, int id)
        {
            var existingVoiture = await voitureRepository.GetById(id);
            if (existingVoiture == null)
            {
                return false;
            }
            var marque = await marqueRepository.GetByName(voiture.Marque);
            var modele = await modeleRepository.GetByName(voiture.Modele);
            var finition = await finitionRepository.GetByName(voiture.Finition);
            var annee = await anneeRepository.GetByValue(voiture.Annee);
            if (marque is null)
            {
                marque = new Marque() { Nom = voiture.Marque };
            }
            if (modele is null)
            {
                modele = new Modele() { Nom = voiture.Modele };
            }
            if (finition is null)
            {
                finition = new Finition() { Nom = voiture.Finition };
            }
            if (annee is null)
            {
                annee = new Annee() { Valeur = voiture.Annee };
            }
            existingVoiture.MarqueId = marque.Id;
            existingVoiture.ModeleId = modele.Id;
            existingVoiture.FinitionId = finition.Id;
            existingVoiture.AnneeId = annee.Id;
            existingVoiture.Marque = marque;
            existingVoiture.Modele = modele;
            existingVoiture.Finition = finition;
            existingVoiture.Annee = annee;
            return await voitureRepository.Update(existingVoiture);
        }

        private async Task<VoitureOutputModel?> ToOutputModel(Voiture voiture)
        {
            var marque = await marqueRepository.GetById(voiture.MarqueId);
            var annee = await anneeRepository.GetById(voiture.AnneeId);
            var modele = await modeleRepository.GetById(voiture.ModeleId);
            var finition = await finitionRepository.GetById(voiture.FinitionId);
            if(marque is null ||
                annee is null ||
                modele is null ||
                finition is null)
            {
                return null;
            }
            return new VoitureOutputModel()
            {
                Id = voiture.Id,
                Marque = marque.Nom,
                Annee = annee.Valeur,
                Modele = modele.Nom,
                Finition = finition.Nom
            };
        }
    }
}