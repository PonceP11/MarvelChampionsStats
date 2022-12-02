using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;

namespace Application.Services;

public class ModularEncounterService: IModularEncounterService
{
    private IModularEncounterRepository _modularEncounterRepository;
    private IMapper _mapper;
    private ModularEncounterValidator _modularEncounterValidator;

    public ModularEncounterService(IModularEncounterRepository modularEncounterRepository, IMapper mapper)
    {
        _modularEncounterRepository = modularEncounterRepository;
        _mapper = mapper;
        _modularEncounterValidator = new ModularEncounterValidator();
    }
    
    public ModularEncounter CreateMatchSet(ModularEncounterDTO dto)
    {
        var validation = _modularEncounterValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return _modularEncounterRepository.CreateMatchSet(_mapper.Map<ModularEncounter>(dto));
    }

    public ModularEncounter GetMatchSetById(int Id)
    {
        ModularEncounter modularEncounter = _modularEncounterRepository.GetMatchSetById(Id);
        if (modularEncounter == null)
            throw new KeyNotFoundException();
        return modularEncounter;
    }

    public List<ModularEncounter> GetAllMatchSets()
    {
        return _modularEncounterRepository.GetAllMatchSets();
    }

    public ModularEncounter UpdateModularEncounter(int Id, ModularEncounter modularEncounter)
    {
        return _modularEncounterRepository.UpdateModularEncounter(Id, modularEncounter);
    }

    public ModularEncounter DeleteModularEncounter(int Id)
    {
        return _modularEncounterRepository.DeleteModularEncounter(Id);
    }

    public void CreateDB()
    {
        _modularEncounterRepository.CreateDB();
    }
}