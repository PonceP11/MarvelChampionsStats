using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;

namespace Application.Services;

public class HeroService: IHeroService
{
    private IHeroRepository _heroRepository;
    private IMapper _mapper;
    private HeroValidator _heroValidator;

    public HeroService(IHeroRepository heroRepository, IMapper mapper)
    {
        _heroRepository = heroRepository;
        _mapper = mapper;
        _heroValidator = new HeroValidator();
    }
    
    public Hero CreateHero(HeroDTO dto)
    {
        var validation = _heroValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return _heroRepository.CreateHero(_mapper.Map<Hero>(dto));
    }

    public Hero GetHeroById(int Id)
    {
        Hero hero = _heroRepository.GetHeroById(Id);
        if (hero == null)
            throw new KeyNotFoundException();
        return hero;
    }

    public List<Hero> GetAllHeroes()
    {
        return _heroRepository.GetAllHeroes();
    }

    public Hero UpdateHero(int Id, Hero hero)
    {
        return _heroRepository.UpdateHero(Id, hero);
    }

    public Hero DeleteHero(int Id)
    {
        return _heroRepository.DeleteHero(Id);
    }

    public void CreateDB()
    {
        _heroRepository.CreateDB();
    }
}