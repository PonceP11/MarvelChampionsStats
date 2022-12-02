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
public class UserController : ControllerBase
{
    private IUserService _userService;
    private IMapper _mapper;

    public UserController(IUserService service, IMapper mapper)
    {
        _userService = service;
        _mapper = mapper;
    }

    [HttpGet]
    public List<User> GetUsers()
    {
        return _userService.GetAllUsers();
    }

    [HttpPost]
    public IActionResult CreateNewUser(UserDTO user)
    {
        try
        {
            return Ok(_userService.CreateUser(user));
        }catch (ValidationException error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet]
    [Route("{Id}")]
    public IActionResult GetUserById(int Id)
    {
        try
        {
            return Ok(_userService.GetUserById(Id));
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
    public IActionResult UpdateUser(int Id, User user)
    {
        try
        {
            return Ok(_userService.UpdateUser(Id, user));
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
    public IActionResult DeleteUser(int id)
    {
        try
        {
            return Ok(_userService.DeleteUser(id));
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