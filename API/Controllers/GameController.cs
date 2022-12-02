using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[Controller]")]
[EnableCors]
public class GameController : ControllerBase
{
    private IGameService _gameService;
    private IMapper _mapper;

    public GameController(IGameService service, IMapper mapper)
    {
        _gameService = service;
        _mapper = mapper;
    }

    [HttpGet]
    public List<Game> GetGames()
    {
        return _gameService.GetAllGames();
    }

    [HttpPost]
    public IActionResult CreateNewGame(GameDTO game)
    {
        try
        {
            return Ok(_gameService.CreateGame(game));
        }
        catch (ValidationException error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet]
    [Route("{Id}")]
    public IActionResult GetGameById(int Id)
    {
        try
        {
            return Ok(_gameService.GetGameById(Id));
        }
        catch (KeyNotFoundException error)
        {
            return NotFound(error.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }
    
    [HttpPut]
    [Route("{Id}")]
    public IActionResult UpdateGame(int Id, Game game)
    {
        try
        {
            return Ok(_gameService.UpdateGame(Id, game));
        }
        catch (KeyNotFoundException error)
        {
            return NotFound(error.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpDelete]
    [Route("{Id}")]
    public IActionResult DeleteGame(int id)
    {
        try
        {
            return Ok(_gameService.DeleteGame(id));
        }
        catch (KeyNotFoundException error)
        {
            return NotFound(error.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }
}