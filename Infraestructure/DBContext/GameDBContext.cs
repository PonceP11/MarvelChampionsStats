using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure;

public class GameDBContext : DbContext
{
    public GameDBContext(DbContextOptions<GameDBContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
    public DbSet<Game> GameTable { get; set; }
}