using ExpressVoitures.Server.Models.Entities;
using ExpressVoitures.Server.Models.InputModels;
using ExpressVoitures.Server.Models.Repositories;

namespace ExpressVoitures.Server.Models.Services
{
    public class AnnonceService : IAnnonceService
    {
        private readonly IAnnonceRepository annonceRepository;
        private readonly IVoitureEnregistreRepository voitureEnregistreRepository;
        private readonly IVoitureRepository voitureRepository;
        private readonly IAnneeRepository anneeRepository;
        private readonly IModeleRepository modeleRepository;
        private readonly IMarqueRepository marqueRepository;
        private readonly IFinitionRepository finitionRepository;
        public AnnonceService(
            IAnnonceRepository annonceRepository,
            IVoitureEnregistreRepository voitureEnregistreRepository,
            IVoitureRepository voitureRepository,
            IMarqueRepository marqueRepository,
            IAnneeRepository anneeRepository,
            IModeleRepository modeleRepository,
            IFinitionRepository finitionRepository)
        {
            this.annonceRepository = annonceRepository;
            this.voitureEnregistreRepository = voitureEnregistreRepository;
            this.voitureRepository = voitureRepository;
            this.anneeRepository = anneeRepository;
            this.modeleRepository = modeleRepository;
            this.marqueRepository = marqueRepository;
            this.finitionRepository = finitionRepository;
        }

        public async Task<IList<AnnonceOutputModel>> GetAll()
        {
            List<AnnonceOutputModel> annoncesOutputModel = [];
            var annonces = await annonceRepository.GetAll();
            foreach (var annonce in annonces)
            {
                annoncesOutputModel.Add(ToOutputModel(annonce));
            }
            return annoncesOutputModel;
        }

        public async Task<IList<AnnonceOutputModel>> GetAllAvailable()
        {
            List<AnnonceOutputModel> annoncesOutputModel = [];
            var annonces = await annonceRepository.GetAllAvailable();
            foreach (var annonce in annonces)
            {
                annoncesOutputModel.Add(ToOutputModel(annonce));
            }
            return annoncesOutputModel;
        }

        public async Task<AnnonceOutputModel?> GetById(int id)
        {
            var annonce = await annonceRepository.GetById(id);
            if (annonce is not null)
            {
                return ToOutputModel(annonce);
            }
            return null;
        }

        public async Task<AnnonceOutputModel?> GetByIdAvailable(int id)
        {
            var annonce = await annonceRepository.GetByIdAvailable(id);
            if (annonce is not null)
            {
                return ToOutputModel(annonce);
            }
            return null;
        }

        public async Task<bool> Create(AnnonceInputModel annonce)
        {
            var result = await ToAnnonce(annonce, 0);
            if (result is not null)
            {
                return await annonceRepository.Create(result);
            }
            return false;
        }

        public async Task<bool> Update(AnnonceInputModel annonce, int id)
        {
            var existingAnnonce = await annonceRepository.GetById(id);
            if (existingAnnonce is null)
            {
                return false;
            }
            existingAnnonce.Titre = annonce.Titre;
            existingAnnonce.Description = annonce.Description;
            existingAnnonce.Photos = annonce.Photos;
            existingAnnonce.PrixVente = annonce.PrixVente;

            return await annonceRepository.Update(existingAnnonce);
        }

        public async Task<bool> DeleteById(int id)
        {
            return await annonceRepository.DeleteById(id);
        }

        public async Task<bool> Sold(int id)
        {
            var annonce = await annonceRepository.GetById(id);
            if (annonce is null)
            {
                return false;
            }
            annonce.DateVente = DateTime.Now;
            await annonceRepository.Update(annonce);
            return true;
        }

        public async Task Upload(IFormFile file, int id)
        {
            var annonce = await annonceRepository.GetById(id);
            if (annonce is not null)
            {
                var nomFichier = $"{annonce.Id}-{annonce.Titre.Replace(' ', '_')}.jpg";
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                File.WriteAllBytes(
                    $"../expressvoitures.client/src/assets/img/annonces/{nomFichier}",
                    memoryStream.ToArray());
            }
        }

        private AnnonceOutputModel ToOutputModel(Annonce annonce)
        {
            return new AnnonceOutputModel()
            {
                Id = annonce.Id,
                Titre = annonce.Titre,
                Description = annonce.Description,
                Photos = annonce.Photos,
                DateCreation = annonce.DateCreation,
                PrixVente = annonce.PrixVente,
                DateVente = annonce.DateVente,
                VoitureEnregistreId = annonce.VoitureEnregistreId
            };
        }

        private async Task<Annonce?> ToAnnonce(AnnonceInputModel annonceInputModel, int id)
        {
            var voitureEnregistre = await voitureEnregistreRepository.GetById(annonceInputModel.VoitureEnregistreId);
            if (voitureEnregistre is null)
            {
                return null;
            }
            var voiture = await voitureRepository.GetById(voitureEnregistre.VoitureId);
            if (voiture is null)
            {
                return null;
            }
            var marque = await marqueRepository.GetById(voiture.MarqueId);
            var annee = await anneeRepository.GetById(voiture.AnneeId);
            var modele = await modeleRepository.GetById(voiture.ModeleId);
            var finition = await finitionRepository.GetById(voiture.FinitionId);
            if (marque is null ||
                annee is null ||
                modele is null ||
                finition is null)
            {
                return null;
            }
            return new Annonce()
            {
                Id = id,
                Titre = $"{marque.Nom} {annee.Valeur} {modele.Nom} {finition.Nom}",
                Description = annonceInputModel.Description,
                Photos = annonceInputModel.Photos,
                DateCreation = DateTime.Now,
                PrixVente = annonceInputModel.PrixVente,
                VoitureEnregistreId = annonceInputModel.VoitureEnregistreId,
                VoitureEnregistre = voitureEnregistre
            };

        }
    }
}
