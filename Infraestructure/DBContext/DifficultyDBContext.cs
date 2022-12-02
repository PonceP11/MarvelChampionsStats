using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure;

public class DifficultyDBContext : DbContext
{
    public DifficultyDBContext(DbContextOptions<DifficultyDBContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Difficulty>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
    
    public DbSet<Difficulty> DifficultyTable { get; set; }
}