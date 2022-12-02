using Domain;

namespace Application.Interfaces;

public interface IGameRepository
{
    public Game CreateGame(Game game);

    public Game GetGameById(int Id);

    public List<Game> GetAllGames();

    public Game UpdateGame(int Id, Game game);

    public Game DeleteGame(int Id);

    public void CreateDB();
}