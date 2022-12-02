using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers;


[ApiController]
[Route("[Controller]")]
[EnableCors]
public class ModularEncounterController : ControllerBase
{
    private IModularEncounterService _modularEncounterService;
    private IMapper _mapper;

    public ModularEncounterController(IModularEncounterService service, IMapper mapper)
    {
        _modularEncounterService = service;
        _mapper = mapper;
    }

    [HttpGet]
    public List<ModularEncounter> GetMatchSets()
    {
        return _modularEncounterService.GetAllMatchSets();
    }

    [HttpPost]
    public IActionResult CreateNewMatchSet(ModularEncounterDTO modularEncounter)
    {
        try
        {
            return Ok(_modularEncounterService.CreateMatchSet(modularEncounter));
        }catch (ValidationException error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet]
    [Route("{Id}")]
    public IActionResult GetMatchSetById(int Id)
    {
        try
        {
            return Ok(_modularEncounterService.GetMatchSetById(Id));
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
    public IActionResult UpdateModularEncounter(int Id, ModularEncounter modularEncounter)
    {
        try
        {
            return Ok(_modularEncounterService.UpdateModularEncounter(Id, modularEncounter));
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
    public IActionResult DeleteModularEncounter(int id)
    {
        try
        {
            return Ok(_modularEncounterService.DeleteModularEncounter(id));
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