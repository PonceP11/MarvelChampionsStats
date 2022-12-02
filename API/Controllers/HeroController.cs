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
public class HeroController : ControllerBase
{
    private IHeroService _heroService;
    private IMapper _mapper;

    public HeroController(IHeroService service, IMapper mapper)
    {
        _heroService = service;
        _mapper = mapper;
    }

    [HttpGet]
    public List<Hero> GetHeroes()
    {
        return _heroService.GetAllHeroes();
    }

    [HttpPost]
    public IActionResult CreateNewHero(HeroDTO hero)
    {
        try
        {
            return Ok(_heroService.CreateHero(hero));
        }catch (ValidationException error)
        {
            return BadRequest(error.Message);
        }
    }
    
    [HttpGet]
    [Route("{Id}")]
    public IActionResult GetHeroById(int Id)
    {
        try
        {
            return Ok(_heroService.GetHeroById(Id));
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
    public IActionResult UpdateHero(int Id, Hero hero)
    {
        try
        {
            return Ok(_heroService.UpdateHero(Id, hero));
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
            return Ok(_heroService.DeleteHero(id));
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