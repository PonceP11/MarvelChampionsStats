using Application.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IAspectService
{
    public Aspect CreateAspect(AspectDTO dto);

    public Aspect GetAspectById(int Id);

    public List<Aspect> GetAllAspects();

    public Aspect UpdateAspect(int Id, Aspect aspect);

    public Aspect DeleteAspect(int Id);

    public void CreateDB();
}