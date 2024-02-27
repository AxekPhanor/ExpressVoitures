using ExpressVoitures.Server.Data;
using ExpressVoitures.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Server.Models.Repositories
{
    public class FinitionRepository : IFinitionRepository
    {
        private readonly ExpressVoituresDbContext _dbContext;
        public FinitionRepository(ExpressVoituresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Finition?> GetById(int id)
        {
            var result = await _dbContext.Finitions.Where(f => f.Id == id).FirstOrDefaultAsync();
            if (result is not null)
            {
                return result;
            }
            return null;
        }

        public async Task<Finition?> GetByName(string name)
        {
            var result = await _dbContext.Finitions.Where(m => m.Nom == name).FirstOrDefaultAsync();
            if (result is not null)
            {
                return result;
            }
            return null;
        }
    }
}
