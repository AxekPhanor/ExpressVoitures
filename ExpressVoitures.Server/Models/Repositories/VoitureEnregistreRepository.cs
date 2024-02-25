﻿using ExpressVoitures.Server.Data;
using ExpressVoitures.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Server.Models.Repositories
{
    public class VoitureEnregistreRepository : IVoitureEnregistreRepository
    {
        private readonly ExpressVoituresDbContext _dbContext;
        public VoitureEnregistreRepository(ExpressVoituresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(VoitureEnregistre voitureEnregistre)
        {
            var result = _dbContext.VoitureEnregistres.Add(voitureEnregistre);
            if (result is not null)
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteById(int id)
        {
            var result = await _dbContext.VoitureEnregistres.Where(ve => ve.Id == id).FirstOrDefaultAsync();
            if (result is not null)
            {
                _dbContext.Remove(result);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IList<VoitureEnregistre>> GetAll()
            => await _dbContext.VoitureEnregistres.ToListAsync();

        public async Task<VoitureEnregistre?> GetById(int id)
        {
            var result = await _dbContext.VoitureEnregistres.Where(ve => ve.Id == id).FirstOrDefaultAsync();
            if (result is not null)
            {
                return result;
            }
            return null;
        }

        public async Task<bool> Update(VoitureEnregistre voitureEnregistre)
        {
            var result = _dbContext.VoitureEnregistres.Update(voitureEnregistre);
            if (result is not null)
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
