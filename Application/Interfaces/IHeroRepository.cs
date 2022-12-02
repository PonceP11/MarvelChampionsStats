using Domain;

namespace Application.Interfaces;

public interface IHeroRepository
{
    public Hero CreateHero(Hero hero);

    public Hero GetHeroById(int Id);

    public List<Hero> GetAllHeroes();

    public Hero UpdateHero(int Id, Hero hero);

    public Hero DeleteHero(int Id);

    public void CreateDB();
}