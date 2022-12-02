using Domain;

namespace Application.Interfaces;

public interface IAspectRepository
{
    public Aspect CreateAspect(Aspect aspect);

    public Aspect GetAspectById(int Id);

    public List<Aspect> GetAllAspects();

    public Aspect UpdateAspect(int Id, Aspect aspect);

    public Aspect DeleteAspect(int Id);

    public void CreateDB();
}