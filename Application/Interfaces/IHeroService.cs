using Application.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IHeroService
{
    public Hero CreateHero(HeroDTO dto);

    public Hero GetHeroById(int Id);

    public List<Hero> GetAllHeroes();

    public Hero UpdateHero(int Id, Hero hero);

    public Hero DeleteHero(int Id);

    public void CreateDB();
}