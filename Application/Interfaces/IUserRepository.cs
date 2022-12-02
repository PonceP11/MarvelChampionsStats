using Domain;

namespace Application.Interfaces;

public interface IUserRepository
{
    public User CreateUser(User user);

    public User GetUserById(int Id);

    public List<User> GetAllUsers();

    public User UpdateUser(int Id, User user);

    public User DeleteUser(int Id);

    public void CreateDB();
}