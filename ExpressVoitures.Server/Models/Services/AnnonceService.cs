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
        public AnnonceService(
            IAnnonceRepository annonceRepository, 
            IVoitureEnregistreRepository voitureEnregistreRepository, 
            IVoitureRepository voitureRepository)
        {
            this.annonceRepository = annonceRepository;
            this.voitureEnregistreRepository = voitureEnregistreRepository;
            this.voitureRepository = voitureRepository;
        }

        public async Task<IList<AnnonceOutputModel>> GetAll()
        {
            List<AnnonceOutputModel> annoncesOutputModel = [];
            var annonces = await annonceRepository.GetAll();
            foreach(var annonce in annonces)
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
            if(existingAnnonce is null)
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

        private AnnonceOutputModel ToOutputModel(Annonce annonce) 
        {
            return new AnnonceOutputModel()
            {
                Id =  annonce.Id,
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
            if (voitureEnregistre is not null)
            {
                var voiture = await voitureRepository.GetById(voitureEnregistre.VoitureId);
                if (voiture is not null)
                {
                    return new Annonce()
                    {
                        Id = id,
                        Titre = $"{voiture.Marque} {voiture.Annee} {voiture.Modele} {voiture.Finition}",
                        Description = annonceInputModel.Description,
                        Photos = annonceInputModel.Photos,
                        DateCreation = DateTime.Now,
                        PrixVente = annonceInputModel.PrixVente,
                        VoitureEnregistreId = annonceInputModel.VoitureEnregistreId,
                        VoitureEnregistre = voitureEnregistre
                    };
                }
            }
            return null;
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
    }
}
