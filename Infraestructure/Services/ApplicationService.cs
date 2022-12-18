using Application.Interfaces;
using Domain;

namespace Infraestructure;

public class ApplicationService : IApplicationService
{
    private DBContext _dbContext;
    private IDifficultyRepository _difficultyRepository;

    public ApplicationService(
        DBContext context, 
        IDifficultyRepository difficultyRepository)
    {
        _dbContext = context;
        _difficultyRepository = difficultyRepository;
    }
    
    public void CreateDB()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();
        FillDatabase();
    }

    public void DeleteDB()
    {
        _dbContext.Database.EnsureDeleted();
    }

    public void FillDatabase()
    {

        Difficulty d = new Difficulty();
        d.Name = "Standard";
        _difficultyRepository.CreateDifficulty(d);
        d = new Difficulty();
        d.Name = "Standard II";
        _difficultyRepository.CreateDifficulty(d);
        d = new Difficulty();
        d.Name = "Expert";
        _difficultyRepository.CreateDifficulty(d);
        d = new Difficulty();
        d.Name = "Expert II";
        _difficultyRepository.CreateDifficulty(d);
        d = new Difficulty();
        d.Name = "Heroic";
        _difficultyRepository.CreateDifficulty(d);
        
    
    }
}