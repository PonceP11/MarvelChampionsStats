using Application.Interfaces;
using Domain;

namespace Infraestructure;

public class GameRepository : IGameRepository
{
    private DBContext _gameDbContext;

    public GameRepository(DBContext context)
    {
        _gameDbContext = context;
    }
    public Game CreateGame(Game game)
    {
        _gameDbContext.GameTable.Add(game);
        _gameDbContext.SaveChanges();
        return game;
    }

    public Game GetGameById(int Id)
    {
        return _gameDbContext.GameTable.Find(Id);
    }

    public List<Game> GetAllGames()
    {
        return _gameDbContext.GameTable.ToList();
    }

    public Game UpdateGame(int Id, Game game)
    {
        _gameDbContext.GameTable.Update(game);
        _gameDbContext.SaveChanges();
        return game;
    }

    public Game DeleteGame(int Id)
    {
        var gameToDelete = _gameDbContext.GameTable.Find(Id) ?? throw new KeyNotFoundException();
        _gameDbContext.GameTable.Remove(gameToDelete);
        _gameDbContext.SaveChanges();
        return gameToDelete;
    }

    public void CreateDB()
    {
        _gameDbContext.Database.EnsureDeleted();
        _gameDbContext.Database.EnsureCreated();
    }
}