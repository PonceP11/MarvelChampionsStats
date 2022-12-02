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
public class AspectController : ControllerBase
{
    private IAspectService _aspectService;
    private IMapper _mapper;

    public AspectController(IAspectService service, IMapper mapper)
    {
        _aspectService = service;
        _mapper = mapper;
    }

    [HttpGet]
    public List<Aspect> GetAspects()
    {
        return _aspectService.GetAllAspects();
    }

    [HttpPost]
    public IActionResult CreateNewAspect(AspectDTO aspect)
    {
        try
        {
            return Ok(_aspectService.CreateAspect(aspect));
        }
        catch (ValidationException error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet]
    [Route("{Id}")]
    public IActionResult GetAspectById(int Id)
    {
        try
        {
            return Ok(_aspectService.GetAspectById(Id));
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
    public IActionResult UpdateAspect(int Id, Aspect aspect)
    {
        try
        {
            return Ok(_aspectService.UpdateAspect(Id, aspect));
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
    public IActionResult DeleteAspect(int id)
    {
        try
        {
            return Ok(_aspectService.DeleteAspect(id));
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