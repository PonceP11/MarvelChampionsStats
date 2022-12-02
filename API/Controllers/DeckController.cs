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
public class DeckController : ControllerBase
{
    private IDeckService _deckService;
    private IMapper _mapper;

    public DeckController(IDeckService service, IMapper mapper)
    {
        _deckService = service;
        _mapper = mapper;
    }

    [HttpGet]
    public List<Deck> GetDecks()
    {
        return _deckService.GetAllDecks();
    }

    [HttpPost]
    public IActionResult CreateNewDeck(DeckDTO deck)
    {
        try
        {
            return Ok(_deckService.CreateDeck(deck));
        }
        catch (ValidationException error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet]
    [Route("{Id}")]
    public IActionResult GetDeckById(int Id)
    {
        try
        {
            return Ok(_deckService.GetDeckById(Id));
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
    public IActionResult UpdateDeck(int Id, Deck deck)
    {
        try
        {
            return Ok(_deckService.UpdateDeck(Id, deck));
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
    public IActionResult DeleteDeck(int id)
    {
        try
        {
            return Ok(_deckService.DeleteDeck(id));
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