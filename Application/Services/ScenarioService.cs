using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;

namespace Application.Services;

public class ScenarioService : IScenarioService
{
    private IScenarioRepository _scenarioRepository;
    private IMapper _mapper;
    private ScenarioValidator _scenarioValidator;

    public ScenarioService(IScenarioRepository scenarioRepository, IMapper mapper)
    {
        _scenarioRepository = scenarioRepository;
        _mapper = mapper;
        _scenarioValidator = new ScenarioValidator();
    }
    public Scenario CreateScenario(ScenarioDTO dto)
    {
        var validation = _scenarioValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return _scenarioRepository.CreateScenario(_mapper.Map<Scenario>(dto));
    }

    public Scenario GetScenarioById(int Id)
    {
        Scenario scenario = _scenarioRepository.GetScenarioById(Id);
        if (scenario == null)
            throw new KeyNotFoundException();
        return scenario;
    }

    public List<Scenario> GetAllScenario()
    {
        return _scenarioRepository.GetAllScenario();
    }

    public Scenario UpdateScenario(int Id, Scenario scenario)
    {
        return _scenarioRepository.UpdateScenario(Id, scenario);
    }

    public Scenario DeleteScenario(int Id)
    {
        return _scenarioRepository.DeleteScenario(Id);
    }

    public void CreateDB()
    {
        _scenarioRepository.CreateDB();
    }
}