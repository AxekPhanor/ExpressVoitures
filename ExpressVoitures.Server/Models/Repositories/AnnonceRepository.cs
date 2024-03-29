﻿using ExpressVoitures.Server.Data;
using ExpressVoitures.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Server.Models.Repositories
{
    public class AnnonceRepository : IAnnonceRepository
    {
        private readonly ExpressVoituresDbContext _dbContext;
        public AnnonceRepository(ExpressVoituresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(Annonce annonce)
        {
            var result = await _dbContext.Annonces.AddAsync(annonce);
            if (result is not null)
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteById(int id)
        {
            var result = _dbContext.Annonces.Where(a => a.Id == id).FirstOrDefault();
            if (result is not null)
            {
                _dbContext.Annonces.Remove(result);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IList<Annonce>> GetAll()
            => await _dbContext.Annonces.ToListAsync();

        public async Task<IList<Annonce>> GetAllAvailable()
            => await _dbContext.Annonces.Where(a => a.DateVente == null).ToListAsync();

        public async Task<Annonce?> GetById(int id)
        {
            var result = await _dbContext.Annonces.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (result is not null)
            {
                return result;
            }
            return null;
        }

        public async Task<Annonce?> GetByIdAvailable(int id)
        {
            var result = await _dbContext.Annonces
                .Where(a => a.Id == id && a.DateVente == null).FirstOrDefaultAsync();
            if (result is not null)
            {
                return result;
            }
            return null;
        }

        public async Task<bool> Update(Annonce annonce)
        {
            var annonceModifier = await _dbContext.Annonces
                .Where(a => a.Id == annonce.Id).FirstOrDefaultAsync();
            if (annonceModifier is null)
            {
                return false;
            }
            annonceModifier.Titre = annonce.Titre;
            annonceModifier.DateVente = annonce.DateVente;
            annonceModifier.PrixVente = annonce.PrixVente;
            annonceModifier.Description = annonce.Description;
            annonceModifier.Photos = annonce.Photos;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckVoitureEnregistreExists(int voitureEnregistreId)
        {
            var result = await _dbContext.VoitureEnregistres
                .Where(ve => ve.Id == voitureEnregistreId)
                .FirstOrDefaultAsync();
            if (result is not null)
            {
                return true;
            }
            return false;
        }
    }
}
