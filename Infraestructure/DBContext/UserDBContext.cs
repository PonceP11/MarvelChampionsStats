using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure;

public class UserDBContext : DbContext
{
    public UserDBContext(DbContextOptions<UserDBContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
    
    public DbSet<User> UserTable { get; set; }
}