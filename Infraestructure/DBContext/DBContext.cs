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
            modelBuilder.Entity<Content>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Difficulty>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Game>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Hero>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<ModularEncounter>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Scenario>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
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