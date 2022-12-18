using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure;

public class AspectRepository : IAspectRepository
{
    private DBContext _aspectDbContext;

    public AspectRepository(DBContext context)
    {
        _aspectDbContext = context;
    }
    public Aspect CreateAspect(Aspect aspect)
    {
        _aspectDbContext.AspectTable.Add(aspect);
        _aspectDbContext.SaveChanges();
        return aspect;
    }

    public Aspect GetAspectById(int Id)
    {
        return _aspectDbContext.AspectTable.Find(Id);
    }

    public List<Aspect> GetAllAspects()
    {
        return _aspectDbContext.AspectTable.ToList();
    }

    public Aspect UpdateAspect(int Id, Aspect aspect)
    {
       
        _aspectDbContext.Entry(aspect).State = EntityState.Modified;
        //_aspectDbContext.AspectTable.Update(aspect);
        _aspectDbContext.SaveChanges();
        return aspect;
    }

    public Aspect DeleteAspect(int Id)
    {
        var aspectToDelete = _aspectDbContext.AspectTable.Find(Id) ?? throw new KeyNotFoundException();
        _aspectDbContext.AspectTable.Remove(aspectToDelete);
        _aspectDbContext.SaveChanges();
        return aspectToDelete;
    }

    public void CreateDB()
    {
        _aspectDbContext.Database.EnsureDeleted();
        _aspectDbContext.Database.EnsureCreated();
    }
}