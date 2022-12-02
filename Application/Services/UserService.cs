using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;

namespace Application.Services;

public class UserService : IUserService
{
    private IUserRepository _userRepository;
    private IMapper _mapper;
    private UserValidator _userValidator;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userValidator = new UserValidator();
    }
    public User CreateUser(UserDTO dto)
    {
        var validation = _userValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return _userRepository.CreateUser(_mapper.Map<User>(dto));
    }

    public User GetUserById(int Id)
    {
        User user = _userRepository.GetUserById(Id);
        if (user == null)
            throw new KeyNotFoundException();
        return user;
    }

    public List<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }

    public User UpdateUser(int Id, User user)
    {
        return _userRepository.UpdateUser(Id, user);
    }

    public User DeleteUser(int Id)
    {
        return _userRepository.DeleteUser(Id);
    }

    public void CreateDB()
    {
        _userRepository.CreateDB();
    }
}