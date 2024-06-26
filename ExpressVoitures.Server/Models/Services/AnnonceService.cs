﻿using ExpressVoitures.Server.Models.Entities;
using ExpressVoitures.Server.Models.InputModels;
using ExpressVoitures.Server.Models.Repositories;

namespace ExpressVoitures.Server.Models.Services
{
    public class AnnonceService : IAnnonceService
    {
        private readonly IAnnonceRepository annonceRepository;
        private readonly IVoitureEnregistreRepository voitureEnregistreRepository;
        public AnnonceService(
            IAnnonceRepository annonceRepository,
            IVoitureEnregistreRepository voitureEnregistreRepository)
        {
            this.annonceRepository = annonceRepository;
            this.voitureEnregistreRepository = voitureEnregistreRepository;
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

        public async Task<bool> Create(AnnonceInputModel annonceInputModel)
        {
            var voitureEnregistre = await voitureEnregistreRepository.GetById(annonceInputModel.VoitureEnregistreId);
            if (voitureEnregistre is null)
            {
                return false;
            }
            var result = new Annonce()
            {
                Titre = $"{voitureEnregistre.Voiture.Marque.Nom} {voitureEnregistre.Voiture.Annee.Valeur} {voitureEnregistre.Voiture.Modele.Nom} {voitureEnregistre.Voiture.Finition.Nom}",
                Description = annonceInputModel.Description,
                Photos = annonceInputModel.Photos,
                DateCreation = DateTime.Now,
                PrixVente = annonceInputModel.PrixVente,
                VoitureEnregistreId = annonceInputModel.VoitureEnregistreId,
                VoitureEnregistre = voitureEnregistre
            };
            return await annonceRepository.Create(result);
        }

        public async Task<bool> Update(AnnonceInputModel annonceInputModel, int id)
        {
            var annonce = await annonceRepository.GetById(id);
            if (annonce is null)
            {
                return false;
            }
            var voitureEnregistreExist = await annonceRepository.CheckVoitureEnregistreExists(annonceInputModel.VoitureEnregistreId);
            if (!voitureEnregistreExist)
            {
                return false;
            }
            annonce.Id = id;
            annonce.Titre = annonceInputModel.Titre;
            annonce.Description = annonceInputModel.Description;
            annonce.Photos = annonceInputModel.Photos;
            annonce.PrixVente = annonceInputModel.PrixVente;
            annonce.VoitureEnregistreId = annonceInputModel.VoitureEnregistreId;
            return await annonceRepository.Update(annonce);
        }

        public async Task<bool> DeleteById(int id)
        {
            var annonce = await annonceRepository.GetById(id);
            if (annonce is null)
            {
                return false;
            }
            annonce.Photos.ForEach(photo =>
            {
                if (File.Exists($"../expressvoitures.client/src/assets/img/annonces/{photo}"))
                {
                    File.Delete($"../expressvoitures.client/src/assets/img/annonces/{photo}");
                }
            });
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

        public async Task<bool> Upload(List<IFormFile> files, int id)
        {
            var voitureEnregistre = await voitureEnregistreRepository.GetById(id);
            if (voitureEnregistre is null)
            {
                return false;
            }

            string directoryPath = "../expressvoitures.client/src/assets/img/annonces";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            for (int i = 0; i < files.Count; i++)
            {
                int counter = 0;
                string nomFichier;
                string marque = voitureEnregistre.Voiture.Marque.Nom.Replace(" ", "_");
                int annee = voitureEnregistre.Voiture.Annee.Valeur;
                string modele = voitureEnregistre.Voiture.Modele.Nom.Replace(" ", "_");
                string finition = voitureEnregistre.Voiture.Finition.Nom.Replace(" ", "_");
                do
                {
                    
                    nomFichier = $"{voitureEnregistre.Id}-{marque}_{annee}_{modele}_{finition}({counter}).jpg";
                    counter++;
                } while (File.Exists(Path.Combine(directoryPath, nomFichier)));

                using var memoryStream = new MemoryStream();
                await files[i].CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                File.WriteAllBytes(
                    Path.Combine(directoryPath, nomFichier),
                    memoryStream.ToArray());
            }
            return true;
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
    }
}
