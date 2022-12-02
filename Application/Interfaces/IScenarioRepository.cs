using Domain;

namespace Application.Interfaces;

public interface IScenarioRepository
{
    public Scenario CreateScenario(Scenario scenario);

    public Scenario GetScenarioById(int Id);

    public List<Scenario> GetAllScenario();

    public Scenario UpdateScenario(int Id, Scenario scenario);

    public Scenario DeleteScenario(int Id);

    public void CreateDB();
}