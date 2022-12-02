using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;

namespace Application.Services;

public class AspectService : IAspectService
{
    private IAspectRepository _aspectRepository;
    private IMapper _mapper;
    private AspectValidator _aspectValidator;

    public AspectService(IAspectRepository aspectRepository, IMapper mapper)
    {
        _aspectRepository = aspectRepository;
        _mapper = mapper;
        _aspectValidator = new AspectValidator();
    }
    public Aspect CreateAspect(AspectDTO dto)
    {
        var validation = _aspectValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return _aspectRepository.CreateAspect(_mapper.Map<Aspect>(dto));
    }

    public Aspect GetAspectById(int Id)
    {
        Aspect aspect = _aspectRepository.GetAspectById(Id);
        if (aspect == null)
            throw new KeyNotFoundException();
        return aspect;
    }

    public List<Aspect> GetAllAspects()
    {
        return _aspectRepository.GetAllAspects();
    }

    public Aspect UpdateAspect(int Id, Aspect aspect)
    {
        return _aspectRepository.UpdateAspect(Id, aspect);
    }

    public Aspect DeleteAspect(int Id)
    {
        return _aspectRepository.DeleteAspect(Id);
    }

    public void CreateDB()
    {
        _aspectRepository.CreateDB();
    }
}