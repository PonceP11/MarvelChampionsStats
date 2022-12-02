using Application.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IScenarioService
{
    public Scenario CreateScenario(ScenarioDTO dto);

    public Scenario GetScenarioById(int Id);

    public List<Scenario> GetAllScenario();

    public Scenario UpdateScenario(int Id, Scenario scenario);

    public Scenario DeleteScenario(int Id);

    public void CreateDB();
}