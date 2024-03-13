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

        public async Task<VoitureOutputModel> Create(VoitureInputModel voiture)
        {
            var marque = await marqueRepository.GetByName(voiture.Marque) ?? new Marque() { Nom = voiture.Marque };
            var modele = await modeleRepository.GetByName(voiture.Modele) ?? new Modele() { Nom = voiture.Modele };
            var finition = await finitionRepository.GetByName(voiture.Finition) ?? new Finition() { Nom = voiture.Finition };
            var annee = await anneeRepository.GetByValue(voiture.Annee) ?? new Annee() { Valeur = voiture.Annee };
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
            return ToOutputModel(await voitureRepository.Create(newVoiture));
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
                var result = ToOutputModel(voiture);
                voituresOutputModel.Add(result);
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
            return ToOutputModel(voiture);
        }

        public async Task<bool> Update(VoitureInputModel voiture, int id)
        {
            var existingVoiture = await voitureRepository.GetById(id);
            if (existingVoiture == null)
            {
                return false;
            }
            var marque = await marqueRepository.GetByName(voiture.Marque) ?? new Marque() { Nom = voiture.Marque };
            var modele = await modeleRepository.GetByName(voiture.Modele) ?? new Modele() { Nom = voiture.Modele };
            var finition = await finitionRepository.GetByName(voiture.Finition) ?? new Finition() { Nom = voiture.Finition };
            var annee = await anneeRepository.GetByValue(voiture.Annee) ?? new Annee() { Valeur = voiture.Annee };
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

        public async Task<IList<VoitureOutputModel>> GetFiltered(string? marque, int? annee, string? modele, string? finition)
        {
            List<VoitureOutputModel> voituresOutputModel = [];
            var voitures = await voitureRepository.GetFiltered(marque, annee, modele, finition);
            foreach (var voiture in voitures)
            {
                var result = ToOutputModel(voiture);
                if (result is not null)
                {
                    voituresOutputModel.Add(result);
                }
            }
            return voituresOutputModel;
        }

        public async Task<VoitureOutputModel?> Exist(VoitureInputModel voiture)
        {
            var marque = await marqueRepository.GetByName(voiture.Marque);
            var modele = await modeleRepository.GetByName(voiture.Modele);
            var finition = await finitionRepository.GetByName(voiture.Finition);
            var annee = await anneeRepository.GetByValue(voiture.Annee);
            if (marque is null ||
                modele is null ||
                finition is null ||
                annee is null)
            {
                return null;
            }
            var existingVoiture = await voitureRepository.Exist(new Voiture()
            {
                MarqueId = marque.Id,
                ModeleId = modele.Id,
                FinitionId = finition.Id,
                AnneeId = annee.Id,
                Marque = marque,
                Modele = modele,
                Finition = finition,
                Annee = annee
            });
            if (existingVoiture is null)
            {
                return null;
            }
            return ToOutputModel(existingVoiture);
        }

        private VoitureOutputModel ToOutputModel(Voiture voiture)
        {
            return new VoitureOutputModel()
            {
                Id = voiture.Id,
                Marque = voiture.Marque.Nom,
                Annee = voiture.Annee.Valeur,
                Modele = voiture.Modele.Nom,
                Finition = voiture.Finition.Nom
            };
        }
    }
}