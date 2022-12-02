using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;

namespace Application.Services;

public class ContentService : IContentService
{
    private IContentRepository _contentRepository;
    private IMapper _mapper;
    private ContentValidator _contentValidator;

    public ContentService(IContentRepository contentRepository, IMapper mapper)
    {
        _contentRepository = contentRepository;
        _mapper = mapper;
        _contentValidator = new ContentValidator();
    }
    public Content CreateContent(ContentDTO dto)
    {
        var validation = _contentValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return _contentRepository.CreateContent(_mapper.Map<Content>(dto));
    }

    public Content GetContentById(int Id)
    {
        Content content = _contentRepository.GetContentById(Id);
        if (content == null)
            throw new KeyNotFoundException();
        return content;
    }

    public List<Content> GetAllContents()
    {
        return _contentRepository.GetAllContents();
    }

    public Content UpdateContent(int Id, Content content)
    {
        return _contentRepository.UpdateContent(Id, content);
    }

    public Content DeleteContent(int Id)
    {
        return _contentRepository.DeleteContent(Id);
    }

    public void CreateDB()
    {
        _contentRepository.CreateDB();
    }
}