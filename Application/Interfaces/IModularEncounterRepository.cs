using Domain;

namespace Application.Interfaces;

public interface IModularEncounterRepository
{
    public ModularEncounter CreateMatchSet(ModularEncounter modularEncounter);

    public ModularEncounter GetMatchSetById(int Id);

    public List<ModularEncounter> GetAllMatchSets();

    public ModularEncounter UpdateModularEncounter(int Id, ModularEncounter modularEncounter);

    public ModularEncounter DeleteModularEncounter(int Id);

    public void CreateDB();
}