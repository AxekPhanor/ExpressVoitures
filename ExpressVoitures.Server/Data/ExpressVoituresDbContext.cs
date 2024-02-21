using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Server.Data
{
    public class ExpressVoituresDbContext : IdentityDbContext
    {
        public ExpressVoituresDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
