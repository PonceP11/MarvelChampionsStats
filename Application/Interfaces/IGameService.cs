using Application.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IGameService
{
    public Game CreateGame(GameDTO dto);

    public Game GetGameById(int Id);

    public List<Game> GetAllGames();

    public Game UpdateGame(int Id, Game game);

    public Game DeleteGame(int Id);

    public void CreateDB();
}