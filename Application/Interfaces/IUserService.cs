using Application.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IUserService
{
    public User CreateUser(UserDTO dto);

    public User GetUserById(int Id);

    public List<User> GetAllUsers();

    public User UpdateUser(int Id, User user);

    public User DeleteUser(int Id);

    public void CreateDB();
}