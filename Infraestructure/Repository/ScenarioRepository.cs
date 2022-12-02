using Application.Interfaces;
using Domain;

namespace Infraestructure;

public class ScenarioRepository : IScenarioRepository
{
    private DBContext _scenarioDbContext;

    public ScenarioRepository(DBContext context)
    {
        _scenarioDbContext = context;
    }
    public Scenario CreateScenario(Scenario scenario)
    {
        _scenarioDbContext.ScenarioTable.Add(scenario);
        _scenarioDbContext.SaveChanges();
        return scenario;
    }

    public Scenario GetScenarioById(int Id)
    {
        return _scenarioDbContext.ScenarioTable.Find(Id);
    }

    public List<Scenario> GetAllScenario()
    {
        return _scenarioDbContext.ScenarioTable.ToList();
    }

    public Scenario UpdateScenario(int Id, Scenario scenario)
    {
        _scenarioDbContext.ScenarioTable.Update(scenario);
        _scenarioDbContext.SaveChanges();
        return scenario;
    }

    public Scenario DeleteScenario(int Id)
    {
        var scenarioToDelete = _scenarioDbContext.ScenarioTable.Find(Id) ?? throw new KeyNotFoundException();
        _scenarioDbContext.ScenarioTable.Remove(scenarioToDelete);
        _scenarioDbContext.SaveChanges();
        return scenarioToDelete;
    }

    public void CreateDB()
    {
        _scenarioDbContext.Database.EnsureDeleted();
        _scenarioDbContext.Database.EnsureCreated();
    }
}