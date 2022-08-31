using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zapas.Data.Models;

namespace Zapas.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext():base()
        {
        }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Zapa>()
                .HasIndex(z => new { z.UserId, z.Name }).IsUnique();

            /*modelBuilder.Entity<InfoZapa>()
                .ToView(nameof(InfoZapa))
                .HasKey(t => t.Id);*/
            }

        public DbSet<Race> Races => Set<Race>();
        public DbSet<Zapa> Zapas => Set<Zapa>();
        public DbSet<RaceType> RaceTypes => Set<RaceType>();
        public DbSet<Place> Places => Set<Place>();
        public DbSet<InfoZapa> InfoZapas => Set<InfoZapa>();
    }
}

