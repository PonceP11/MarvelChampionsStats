using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure;

public class AspectDBContext : DbContext
{
    public AspectDBContext(DbContextOptions<AspectDBContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aspect>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
    public DbSet<Aspect> AspectTable { get; set; }
}