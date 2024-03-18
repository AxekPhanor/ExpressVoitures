using ExpressVoitures.Server.Data;
using ExpressVoitures.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Server.Models.Repositories
{
    public class VoitureRepository : IVoitureRepository
    {
        private readonly ExpressVoituresDbContext _dbContext;
        public VoitureRepository(ExpressVoituresDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Voiture> Create(Voiture voiture)
        {
            await _dbContext.Voitures.AddAsync(voiture);
            await _dbContext.SaveChangesAsync();
            return voiture;
        }

        public async Task<bool> DeleteById(int id)
        {
            var result = _dbContext.Voitures.Where(v => v.Id == id).FirstOrDefault();
            if (result is not null)
            {
                _dbContext.Voitures.Remove(result);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IList<Voiture>> GetAll()
            => await _dbContext.Voitures
            .Include(v => v.Marque)
            .Include(v => v.Annee)
            .Include(v => v.Modele)
            .Include(v => v.Finition)
            .ToListAsync();

        public async Task<Voiture?> GetById(int id)
        {
            return await _dbContext.Voitures
                .Include(v => v.Marque)
                .Include(v => v.Annee)
                .Include(v => v.Modele)
                .Include(v => v.Finition)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<bool> Update(Voiture voiture)
        {
            var result = await _dbContext.Voitures
                .Include(v => v.Marque)
                .Include(v => v.Annee)
                .Include(v => v.Modele)
                .Include(v => v.Finition)
                .Where(v => v.Id == voiture.Id)
                .FirstOrDefaultAsync();
            if (result is not null)
            {
                _dbContext.Voitures.Update(voiture);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Voiture?> Exist(Voiture voiture)
        {
            var result = await _dbContext.Voitures
                .Where(v => v.MarqueId == voiture.MarqueId && 
                v.ModeleId == voiture.ModeleId && 
                v.AnneeId == voiture.AnneeId && 
                v.FinitionId == voiture.FinitionId)
                .FirstOrDefaultAsync();
            return result;
        }
    }
}
