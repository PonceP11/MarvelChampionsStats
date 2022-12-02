using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure;

public class ContentDBContext : DbContext
{
    public ContentDBContext(DbContextOptions<ContentDBContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Content>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
    public DbSet<Content> ContentTable { get; set; }
}