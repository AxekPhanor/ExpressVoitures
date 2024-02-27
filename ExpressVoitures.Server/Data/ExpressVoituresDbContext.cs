using ExpressVoitures.Server.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Server.Data
{
    public class ExpressVoituresDbContext : IdentityDbContext
    {
        public DbSet<Voiture> Voitures { get; set; }
        public DbSet<VoitureEnregistre> VoitureEnregistres { get; set; }
        public DbSet<Annonce> Annonces { get; set; }
        public DbSet<Marque> Marques { get; set; }
        public DbSet<Annee> Annees { get; set; }
        public DbSet<Modele> Modeles { get; set; }
        public DbSet<Finition> Finitions { get; set; }

        public ExpressVoituresDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}