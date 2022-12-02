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
public class DifficultyController : ControllerBase
{
    private IDifficultyService _difficultyService;
    private IMapper _mapper;

    public DifficultyController(IDifficultyService service, IMapper mapper)
    {
        _difficultyService = service;
        _mapper = mapper;
    }

    [HttpGet]
    public List<Difficulty> GetDifficulty()
    {
        return _difficultyService.GetAllDifficulty();
    }

    [HttpPost]
    public IActionResult CreateNewDifficulty(DifficultyDTO dto)
    {
        try
        {
            return Ok(_difficultyService.CreateDifficulty(dto));
        }
        catch (ValidationException error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet]
    [Route("{Id}")]
    public IActionResult GetDifficultyById(int Id)
    {
        try
        {
            return Ok(_difficultyService.GetDifficultyById(Id));
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
    public IActionResult UpdateDifficulty(int Id, Difficulty difficulty)
    {
        try
        {
            return Ok(_difficultyService.UpdateDifficulty(Id, difficulty));
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
    public IActionResult DeleteDifficulty(int id)
    {
        try
        {
            return Ok(_difficultyService.DeleteDifficulty(id));
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