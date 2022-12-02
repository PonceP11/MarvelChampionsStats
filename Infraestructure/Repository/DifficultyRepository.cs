using Application.Interfaces;
using Domain;

namespace Infraestructure;

public class DifficultyRepository : IDifficultyRepository
{
    private DBContext _difficultyDbContext;

    public DifficultyRepository(DBContext context)
    {
        _difficultyDbContext = context;
    }
    public Difficulty CreateDifficulty(Difficulty difficulty)
    {
        _difficultyDbContext.DifficultyTable.Add(difficulty);
        _difficultyDbContext.SaveChanges();
        return difficulty;
    }

    public Difficulty GetDifficultyById(int Id)
    {
        return _difficultyDbContext.DifficultyTable.Find(Id);
    }

    public List<Difficulty> GetAllDifficulty()
    {
        return _difficultyDbContext.DifficultyTable.ToList();
    }

    public Difficulty UpdateDifficulty(int Id, Difficulty difficulty)
    {
        _difficultyDbContext.DifficultyTable.Update(difficulty);
        _difficultyDbContext.SaveChanges();
        return difficulty;
    }

    public Difficulty DeleteDifficulty(int Id)
    {
        var difficultyToDelete = _difficultyDbContext.DifficultyTable.Find(Id) ?? throw new KeyNotFoundException();
        _difficultyDbContext.DifficultyTable.Remove(difficultyToDelete);
        _difficultyDbContext.SaveChanges();
        return difficultyToDelete;
    }

    public void CreateDB()
    {
        _difficultyDbContext.Database.EnsureDeleted();
        _difficultyDbContext.Database.EnsureCreated();
    }
}