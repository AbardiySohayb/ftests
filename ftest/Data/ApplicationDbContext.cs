using ftest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ftest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Etd> Etd { get; set; }
        public DbSet<Prof> Prof { get; set; }
        public DbSet<Dem> Dem { get; set; }
        public DbSet<EtdProf> EtdProf { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EtdProf>()
                .HasOne(b => b.Etd)
                .WithMany(ba => ba.EtdProfs)
                .HasForeignKey(bi => bi.EtdId);

            modelBuilder.Entity<EtdProf>()
              .HasOne(b => b.Prof)
              .WithMany(ba => ba.EtdProfs)
              .HasForeignKey(bi => bi.ProfId);

            

            base.OnModelCreating(modelBuilder);
        }
        
          

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Prof>().
                HasMany(x=>x.EtdProf).
                WithOne(y=>y.Prof)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Etd>().
                HasMany(x => x.EtdProf).
                WithOne(y => y.Etd)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }







        /*public DbSet<EtdProf> EtdProfs{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration pour la table d'association EtdProf
            modelBuilder.Entity<EtdProf>()
                .HasKey(ep => new { ep.EtdId, ep.ProfId });

            // Configuration de la relation many-to-many entre Etd et Prof via EtdProf
            modelBuilder.Entity<EtdProf>()
                .HasOne(ep => ep.Etd)
                .WithMany(e => e.EtdProfs)
                .HasForeignKey(ep => ep.EtdId);

            modelBuilder.Entity<EtdProf>()
                .HasOne(ep => ep.Prof)
                .WithMany(p => p.EtdProfs)
                .HasForeignKey(ep => ep.ProfId);
        }*/




    }
}