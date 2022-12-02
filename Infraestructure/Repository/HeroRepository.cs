using Application.Interfaces;
using Domain;

namespace Infraestructure;

public class HeroRepository : IHeroRepository
{
    private DBContext _heroDbContext;

    public HeroRepository(DBContext context)
    {
        _heroDbContext = context;
    }

    public Hero CreateHero(Hero hero)
    {
        _heroDbContext.HeroTable.Add(hero);
        _heroDbContext.SaveChanges();
        return hero;
    }

    public Hero GetHeroById(int Id)
    {
        return _heroDbContext.HeroTable.Find(Id);
    }

    public List<Hero> GetAllHeroes()
    {
        return _heroDbContext.HeroTable.ToList();
    }

    public Hero UpdateHero(int Id, Hero hero)
    {
        _heroDbContext.HeroTable.Update(hero);
        _heroDbContext.SaveChanges();
        return hero;
    }

    public Hero DeleteHero(int Id)
    {
        var heroToDelete = _heroDbContext.HeroTable.Find(Id) ?? throw new KeyNotFoundException();
        _heroDbContext.HeroTable.Remove(heroToDelete);
        _heroDbContext.SaveChanges();
        return heroToDelete;
    }

    public void CreateDB()
    {
        _heroDbContext.Database.EnsureDeleted();
        _heroDbContext.Database.EnsureCreated();
    }
}