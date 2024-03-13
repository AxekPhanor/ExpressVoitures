using ExpressVoitures.Server.Data;
using ExpressVoitures.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Server.Models.Repositories
{
    public class ModeleRepository : IModeleRepository
    {
        private readonly ExpressVoituresDbContext _dbContext;
        public ModeleRepository(ExpressVoituresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Modele?> GetById(int id)
        {
            var result = await _dbContext.Modeles.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (result is not null)
            {
                return result;
            }
            return null;
        }

        public async Task<Modele?> GetByName(string name)
        {
            var result = await _dbContext.Modeles.Where(m => m.Nom == name).FirstOrDefaultAsync();
            if (result is not null)
            {
                return result;
            }
            return null;
        }

        public async Task<IList<Modele>> GetAll()
            => await _dbContext.Modeles.ToListAsync();
    }
}
