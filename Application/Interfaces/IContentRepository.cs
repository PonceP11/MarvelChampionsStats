using Domain;

namespace Application.Interfaces;

public interface IContentRepository
{
    public Content CreateContent(Content content);

    public Content GetContentById(int Id);

    public List<Content> GetAllContents();

    public Content UpdateContent(int Id, Content content);

    public Content DeleteContent(int Id);

    public void CreateDB();
}