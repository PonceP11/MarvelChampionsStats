using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure;

public class HeroDBContext : DbContext
{
    public HeroDBContext(DbContextOptions<HeroDBContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hero>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
    
    public DbSet<Hero> HeroTable { get; set; }
}