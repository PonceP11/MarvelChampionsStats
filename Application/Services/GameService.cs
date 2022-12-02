using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;

namespace Application.Services;

public class GameService : IGameService
{
    private IGameRepository _gameRepository;
    private IMapper _mapper;
    private GameValidator _gameValidator;

    public GameService(IGameRepository gameRepository, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
        _gameValidator = new GameValidator();
    }
    public Game CreateGame(GameDTO dto)
    {
        var validation = _gameValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return _gameRepository.CreateGame(_mapper.Map<Game>(dto));
    }

    public Game GetGameById(int Id)
    {
        Game game = _gameRepository.GetGameById(Id);
        if (game == null)
            throw new KeyNotFoundException();
        return game;
    }

    public List<Game> GetAllGames()
    {
        return _gameRepository.GetAllGames();
    }

    public Game UpdateGame(int Id, Game game)
    {
        return _gameRepository.UpdateGame(Id, game);
    }

    public Game DeleteGame(int Id)
    {
        return _gameRepository.DeleteGame(Id);
    }

    public void CreateDB()
    {
        _gameRepository.CreateDB();
    }
}