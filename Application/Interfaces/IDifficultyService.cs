using Application.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IDifficultyService
{
    public Difficulty CreateDifficulty(DifficultyDTO dto);

    public Difficulty GetDifficultyById(int Id);

    public List<Difficulty> GetAllDifficulty();

    public Difficulty UpdateDifficulty(int Id, Difficulty difficulty);

    public Difficulty DeleteDifficulty(int Id);

    public void CreateDB();
}