using Microsoft.EntityFrameworkCore;
using FitnessClubAPI.Models;

namespace FitnessClubAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClientProgram> ClientPrograms { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<FitnessProgram> FitnessPrograms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClientProgram>(entity =>
            {
                entity.ToTable("ClientProgram");

                entity.HasKey(e => e.IdClientProgram);

                entity.Property(e => e.IdClientProgram)
                      .ValueGeneratedOnAdd();

                entity.HasOne(e => e.Client)
                      .WithMany(c => c.ClientPrograms)
                      .HasForeignKey(e => e.IdClient)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.FitnessProgram)
                      .WithMany(fp => fp.ClientPrograms)
                      .HasForeignKey(e => e.IdFitnessProgram)
                      .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Coach>(entity =>
                {
                    entity.ToTable("Coach");

                    entity.HasKey(e => e.IdCoach);

                    entity.Property(e => e.IdCoach)
                          .ValueGeneratedOnAdd();

                    entity.HasOne(e => e.FitnessClub)
                          .WithMany(fc => fc.Coaches)
                          .HasForeignKey(e => e.IdFitnessClub)
                          .OnDelete(DeleteBehavior.Cascade);

                    entity.HasOne(e => e.FitnessProgram)
                          .WithMany(pf => pf.Coaches)
                          .HasForeignKey(e => e.IdProgram)
                          .OnDelete(DeleteBehavior.Cascade);
                });

                // Configuration for Client and FitnessProgram if needed
            });
        }
        public DbSet<FitnessClubAPI.Models.Coach> Coach { get; set; } = default!;
        public DbSet<FitnessClubAPI.Models.FitnessClub> FitnessClub { get; set; } = default!;

    } 
}
