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
        public async Task<bool> Create(Voiture voiture)
        {
            var result = await _dbContext.Voitures.AddAsync(voiture);
            if (result is not null)
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
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
            => await _dbContext.Voitures.ToListAsync();

        public async Task<Voiture?> GetById(int id)
        {
            var result = await _dbContext.Voitures.Where(v => v.Id == id).FirstOrDefaultAsync();
            if (result is not null)
            {
                return result;
            }
            return null;
        }

        public async Task<bool> Update(Voiture voiture)
        {
            var result = await _dbContext.Voitures.Where(v => v.Id == voiture.Id).FirstOrDefaultAsync();
            if (result is not null)
            {
                _dbContext.Voitures.Update(voiture);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
