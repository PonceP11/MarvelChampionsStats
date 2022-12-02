using Application.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IModularEncounterService
{
    public ModularEncounter CreateMatchSet(ModularEncounterDTO dto);

    public ModularEncounter GetMatchSetById(int Id);

    public List<ModularEncounter> GetAllMatchSets();

    public ModularEncounter UpdateModularEncounter(int Id, ModularEncounter modularEncounter);

    public ModularEncounter DeleteModularEncounter(int Id);

    public void CreateDB();
}