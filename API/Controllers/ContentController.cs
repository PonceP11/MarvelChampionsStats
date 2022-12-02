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
public class ContentController : ControllerBase
{
    private IContentService _contentService;
    private IMapper _mapper;

    public ContentController(IContentService service, IMapper mapper)
    {
        _contentService = service;
        _mapper = mapper;
    }

    [HttpGet]
    public List<Content> GetContents()
    {
        return _contentService.GetAllContents();
    }

    [HttpPost]
    public IActionResult CreateNewContent(ContentDTO contentDto)
    {
        try
        {
            return Ok(_contentService.CreateContent(contentDto));
        }
        catch (ValidationException error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet]
    [Route("{Id}")]
    public IActionResult GetContentById(int Id)
    {
        try
        {
            return Ok(_contentService.GetContentById(Id));
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
    public IActionResult UpdateContent(int Id, Content content)
    {
        try
        {
            return Ok(_contentService.UpdateContent(Id, content));
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
    public IActionResult DeleteContent(int id)
    {
        try
        {
            return Ok(_contentService.DeleteContent(id));
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