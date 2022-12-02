using Application.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IContentService
{
    public Content CreateContent(ContentDTO dto);

    public Content GetContentById(int Id);

    public List<Content> GetAllContents();

    public Content UpdateContent(int Id, Content content);

    public Content DeleteContent(int Id);

    public void CreateDB();
}