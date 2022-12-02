using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure;

public class ScenarioDBContext : DbContext
{
    public ScenarioDBContext(DbContextOptions<ScenarioDBContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Scenario>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
    public DbSet<Scenario> StageTable { get; set; }
}