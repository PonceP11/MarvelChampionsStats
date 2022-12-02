using Application.Interfaces;
using Domain;

namespace Infraestructure;

public class UserRepository : IUserRepository
{
    private DBContext _userDbContext;

    public UserRepository(DBContext context)
    {
        _userDbContext = context;
    }
    public User CreateUser(User user)
    {
        _userDbContext.UserTable.Add(user);
        _userDbContext.SaveChanges();
        return user;
    }

    public User GetUserById(int Id)
    {
        return _userDbContext.UserTable.Find(Id);
    }

    public List<User> GetAllUsers()
    {
        return _userDbContext.UserTable.ToList();
    }

    public User UpdateUser(int Id, User user)
    {
        _userDbContext.UserTable.Update(user);
        _userDbContext.SaveChanges();
        return user;
    }

    public User DeleteUser(int Id)
    {
        var userToDelete = _userDbContext.UserTable.Find(Id) ?? throw new KeyNotFoundException();
        _userDbContext.UserTable.Remove(userToDelete);
        _userDbContext.SaveChanges();
        return userToDelete;
    }

    public void CreateDB()
    {
        _userDbContext.Database.EnsureDeleted();
        _userDbContext.Database.EnsureCreated();
    }
}