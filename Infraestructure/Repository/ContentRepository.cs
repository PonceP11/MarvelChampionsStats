using Application.Interfaces;
using Domain;

namespace Infraestructure;

public class ContentRepository : IContentRepository
{
    private DBContext _dbContext;

    public ContentRepository(DBContext context)
    {
        _dbContext = context;
    }
    public Content CreateContent(Content content)
    {
        _dbContext.ContentTable.Add(content);
        _dbContext.SaveChanges();
        return content;
    }

    public Content GetContentById(int Id)
    {
        return _dbContext.ContentTable.Find(Id);
    }

    public List<Content> GetAllContents()
    {
        return _dbContext.ContentTable.ToList();
    }

    public Content UpdateContent(int Id, Content content)
    {
        _dbContext.ContentTable.Update(content);
        _dbContext.SaveChanges();
        return content;
    }

    public Content DeleteContent(int Id)
    {
        var contentToDelete = _dbContext.ContentTable.Find(Id) ?? throw new KeyNotFoundException();
        _dbContext.ContentTable.Remove(contentToDelete);
        _dbContext.SaveChanges();
        return contentToDelete;
    }

    public void CreateDB()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();
    }
}