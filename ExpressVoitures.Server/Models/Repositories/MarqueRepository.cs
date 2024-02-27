using ExpressVoitures.Server.Data;
using ExpressVoitures.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Server.Models.Repositories
{
    public class MarqueRepository : IMarqueRepository
    {
        private readonly ExpressVoituresDbContext _dbContext;
        public MarqueRepository(ExpressVoituresDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Marque?> GetById(int id)
        {
            var result = await _dbContext.Marques.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (result is not null)
            {
                return result;
            }
            return null;
        }

        public async Task<Marque?> GetByName(string name)
        {
            var result = await _dbContext.Marques.Where(m => m.Nom == name).FirstOrDefaultAsync();
            if (result is not null)
            {
                return result;
            }
            return null;
        }
    }
}
