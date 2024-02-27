using ExpressVoitures.Server.Data;
using ExpressVoitures.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Server.Models.Repositories
{
    public class AnneeRepository : IAnneeRepository
    {
        private readonly ExpressVoituresDbContext _dbContext;
        public AnneeRepository(ExpressVoituresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Annee?> GetById(int id)
        {
            var result = await _dbContext.Annees.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (result is not null)
            {
                return result;
            }
            return null;
        }

        public async Task<Annee?> GetByValue(int value)
        {
            var result = await _dbContext.Annees.Where(m => m.Valeur == value).FirstOrDefaultAsync();
            if (result is not null)
            {
                return result;
            }
            return null;
        }
    }
}
