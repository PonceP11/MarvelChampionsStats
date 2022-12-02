using Application.Interfaces;
using Domain;

namespace Infraestructure;

public class ModularEncounterRepository : IModularEncounterRepository
{
    private DBContext _modularEncounterDbContext;

    public ModularEncounterRepository(DBContext context)
    {
        _modularEncounterDbContext = context;
    }
    public ModularEncounter CreateMatchSet(ModularEncounter modularEncounter)
    {
        _modularEncounterDbContext.ModularEncounterTable.Add(modularEncounter);
        _modularEncounterDbContext.SaveChanges();
        return modularEncounter;
    }

    public ModularEncounter GetMatchSetById(int Id)
    {
        return _modularEncounterDbContext.ModularEncounterTable.Find(Id);
    }

    public List<ModularEncounter> GetAllMatchSets()
    {
        return _modularEncounterDbContext.ModularEncounterTable.ToList();
    }

    public ModularEncounter UpdateModularEncounter(int Id, ModularEncounter modularEncounter)
    {
        _modularEncounterDbContext.ModularEncounterTable.Update(modularEncounter);
        _modularEncounterDbContext.SaveChanges();
        return modularEncounter;
    }

    public ModularEncounter DeleteModularEncounter(int Id)
    {
        var modularEncounterToDelete = _modularEncounterDbContext.ModularEncounterTable.Find(Id) ?? throw new KeyNotFoundException();
        _modularEncounterDbContext.ModularEncounterTable.Remove(modularEncounterToDelete);
        _modularEncounterDbContext.SaveChanges();
        return modularEncounterToDelete;
    }

    public void CreateDB()
    {
        _modularEncounterDbContext.Database.EnsureDeleted();
        _modularEncounterDbContext.Database.EnsureCreated();
    }
}