using ExpressVoitures.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Server.Data
{
    public class ExpressVoituresDbContext : IdentityDbContext
    {
        public DbSet<Voiture> Voitures { get; set; }
        public DbSet<VoitureEnregistre> VoitureEnregistres { get; set; }
        public DbSet<Annonce> Annonces { get; set; }

        public ExpressVoituresDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voiture>()
                .HasMany(e => e.VoituresEnregistre)
                .WithOne(e => e.Voiture)
                .HasForeignKey(e => e.Id)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<VoitureEnregistre>()
                .HasOne(e => e.Annonce)
                .WithOne(e => e.VoitureEnregistre)
                .HasForeignKey<Annonce>(e => e.Id)
                .HasPrincipalKey<VoitureEnregistre>(e => e.Id);

            modelBuilder.Entity<Annonce>()
                .HasOne(e => e.VoitureEnregistre)
                .WithOne(e => e.Annonce)
                .HasForeignKey<VoitureEnregistre>(e => e.Id)
                .HasPrincipalKey<Annonce>(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
