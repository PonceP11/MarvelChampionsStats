using Domain;

namespace Application.Interfaces;

public interface IDifficultyRepository
{
    public Difficulty CreateDifficulty(Difficulty difficulty);

    public Difficulty GetDifficultyById(int Id);

    public List<Difficulty> GetAllDifficulty();

    public Difficulty UpdateDifficulty(int Id, Difficulty difficulty);

    public Difficulty DeleteDifficulty(int Id);

    public void CreateDB();
}