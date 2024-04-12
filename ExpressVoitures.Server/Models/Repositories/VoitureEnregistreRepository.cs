using ExpressVoitures.Server.Data;
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

        public async Task<VoitureEnregistre> Create(VoitureEnregistre voitureEnregistre)
        {
            _dbContext.VoitureEnregistres.Add(voitureEnregistre);
            await _dbContext.SaveChangesAsync();
            return voitureEnregistre;
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
            => await _dbContext.VoitureEnregistres.Include(ve => ve.Voiture)
                .Include(ve => ve.Voiture)
                .ThenInclude(v => v.Marque)
                .Include(ve => ve.Voiture)
                .ThenInclude(v => v.Modele)
                .Include(ve => ve.Voiture)
                .ThenInclude(v => v.Finition)
                .Include(ve => ve.Voiture)
                .ThenInclude(v => v.Annee)
                .ToListAsync();

        public async Task<VoitureEnregistre?> GetById(int id)
        {
            var result = await _dbContext.VoitureEnregistres
                .Include(ve => ve.Voiture)
                .ThenInclude(v => v.Marque)
                .Include(ve => ve.Voiture)
                .ThenInclude(v => v.Modele)
                .Include(ve => ve.Voiture)
                .ThenInclude(v => v.Finition)
                .Include(ve => ve.Voiture)
                .ThenInclude(v => v.Annee)
                .Where(ve => ve.Id == id)
                .FirstOrDefaultAsync();
            if (result is not null)
            {
                return result;
            }
            return null;
        }

        public async Task<bool> Update(VoitureEnregistre voitureEnregistre)
        {
            _dbContext.VoitureEnregistres.Update(voitureEnregistre);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckVoitureExists(int voitureId)
        {
            var result = await _dbContext.Voitures
                .Where(v => v.Id == voitureId)
                .FirstOrDefaultAsync();
            if (result is not null)
            {
                return true;
            }
            return false;
        }
    }
}
