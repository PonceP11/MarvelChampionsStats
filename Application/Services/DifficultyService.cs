using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;

namespace Application.Services;

public class DifficultyService : IDifficultyService
{
    private IDifficultyRepository _difficultyRepository;
    private IMapper _mapper;
    private DifficultyValidator _difficultyValidator;

    public DifficultyService(IDifficultyRepository difficultyRepository, IMapper mapper)
    {
        _difficultyRepository = difficultyRepository;
        _mapper = mapper;
        _difficultyValidator = new DifficultyValidator();
    }
    public Difficulty CreateDifficulty(DifficultyDTO dto)
    {
        var validation = _difficultyValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return _difficultyRepository.CreateDifficulty(_mapper.Map<Difficulty>(dto));
    }

    public Difficulty GetDifficultyById(int Id)
    {
        Difficulty difficulty = _difficultyRepository.GetDifficultyById(Id);
        if (difficulty == null)
            throw new KeyNotFoundException();
        return difficulty;
    }

    public List<Difficulty> GetAllDifficulty()
    {
        return _difficultyRepository.GetAllDifficulty();
    }

    public Difficulty UpdateDifficulty(int Id, Difficulty difficulty)
    {
        return _difficultyRepository.UpdateDifficulty(Id, difficulty);
    }

    public Difficulty DeleteDifficulty(int Id)
    {
        return _difficultyRepository.DeleteDifficulty(Id);
    }

    public void CreateDB()
    {
        _difficultyRepository.CreateDB();
    }
}