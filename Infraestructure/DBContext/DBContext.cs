using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure;

public class DBContext : DbContext
{
    
        public DBContext(DbContextOptions<DBContext> opts) : base(opts)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deck>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Aspect>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Content>(entity =>
            {
                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd();
               /* entity.HasMany<Hero>(h => h.Heroes)
                    .WithOne(e => e.Content)
                    .HasForeignKey(p =>p.ContentId);*/

                //   entity.HasMany(c => c.Heroes)
                //         .WithOne(e => e.Content);
            });
            
            modelBuilder.Entity<Difficulty>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Game>(entity =>
                {
                    entity.Property(p => p.Id)
                        .ValueGeneratedOnAdd();
                    entity.HasOne<Aspect>(p => p.Aspect)
                        .WithMany()
                        .HasForeignKey(c => c.AspectId);
                    entity.HasOne<Difficulty>(p => p.Difficulty)
                        .WithMany()
                        .HasForeignKey(c => c.DifficultyId);
                  entity.HasOne<Hero>(p => p.Hero)
                        .WithMany()
                        .HasForeignKey(c => c.HeroId);
                    entity.HasOne<Scenario>(p => p.Scenario)
                        .WithMany()
                        .HasForeignKey(c => c.ScenarioId);
                })
                ;
            modelBuilder.Entity<Hero>(entity =>
            {
                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd();
                entity.HasOne<Content>(c => c.Content)
                    .WithMany()
                    .HasForeignKey(c => c.ContentId);
            });
                
            modelBuilder.Entity<ModularEncounter>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Scenario>(entity =>
            {
                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd();
                entity.HasOne<Content>(p => p.Content)
                    .WithMany()
                    .HasForeignKey(c => c.ContentId);
            });
            modelBuilder.Entity<User>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    
        public DbSet<Deck> DeckTable { get; set; }
        
        public DbSet<Aspect> AspectTable { get; set; }
        
        public DbSet<Content> ContentTable { get; set; }
        
        public DbSet<Difficulty> DifficultyTable { get; set; }
    
        public DbSet<Game> GameTable { get; set; }
        
        public DbSet<Hero> HeroTable { get; set; }
        
        public DbSet<ModularEncounter> ModularEncounterTable { get; set; }
        
        public DbSet<Scenario> ScenarioTable { get; set; }
        
        public DbSet<User> UserTable { get; set; }
}