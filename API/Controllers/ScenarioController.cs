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
public class ScenarioController : ControllerBase
{
    private IScenarioService _scenarioService;
    private IMapper _mapper;

    public ScenarioController(IScenarioService service, IMapper mapper)
    {
        _scenarioService = service;
        _mapper = mapper;
    }

    [HttpGet]
    public List<Scenario> GetStages()
    {
        return _scenarioService.GetAllScenario();
    }

    [HttpPost]
    public IActionResult CreateNewStage(ScenarioDTO scenario)
    {
        try
        {
            return Ok(_scenarioService.CreateScenario(scenario));
        }
        catch (ValidationException error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet]
    [Route("{Id}")]
    public IActionResult GetStageById(int Id)
    {
        try
        {
            return Ok(_scenarioService.GetScenarioById(Id));
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
    public IActionResult UpdateScenario(int Id, Scenario scenario)
    {
        try
        {
            return Ok(_scenarioService.UpdateScenario(Id, scenario));
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
    public IActionResult DeleteHero(int id)
    {
        try
        {
            return Ok(_scenarioService.DeleteScenario(id));
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