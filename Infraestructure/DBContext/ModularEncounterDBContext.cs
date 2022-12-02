using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure;

public class ModularEncounterDBContext : DbContext
{
    public ModularEncounterDBContext(DbContextOptions<ModularEncounterDBContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ModularEncounter>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
    public DbSet<ModularEncounter> MatchSetTable { get; set; }
}