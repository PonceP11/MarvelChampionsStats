using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure;

public class DeckDBContext : DbContext
{
    public DeckDBContext(DbContextOptions<DeckDBContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Deck>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
    
    public DbSet<Deck> DeckTable { get; set; }
}