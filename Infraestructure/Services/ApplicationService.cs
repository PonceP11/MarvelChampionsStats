using Application.Interfaces;

namespace Infraestructure;

public class ApplicationService : IApplicationService
{
    private DBContext _dbContext;

    public ApplicationService(DBContext context)
    {
        _dbContext = context;
    }
    
    public void CreateDB()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();
    }

    public void DeleteDB()
    {
        _dbContext.Database.EnsureDeleted();
    }
}