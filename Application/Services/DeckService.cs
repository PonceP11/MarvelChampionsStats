using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;

namespace Application.Services;

public class DeckService : IDeckService
{
    private IDeckRepository _deckRepository;
    private IMapper _mapper;
    private DeckValidator _deckValidator;

    public DeckService(IDeckRepository deckRepository, IMapper mapper)
    {
        _deckRepository = deckRepository;
        _mapper = mapper;
        _deckValidator = new DeckValidator();
    }
    public Deck CreateDeck(DeckDTO dto)
    {
        var validation = _deckValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return _deckRepository.CreateDeck(_mapper.Map<Deck>(dto));
    }

    public Deck GetDeckById(int Id)
    {
        Deck deck = _deckRepository.GetDeckById(Id);
        if (deck == null)
            throw new KeyNotFoundException();
        return deck;
    }

    public List<Deck> GetAllDecks()
    {
        return _deckRepository.GetAllDecks();
    }

    public Deck UpdateDeck(int Id, Deck deck)
    {
        return _deckRepository.UpdateDeck(Id, deck);
    }

    public Deck DeleteDeck(int Id)
    {
        return _deckRepository.DeleteDeck(Id);
    }

    public void CreateDB()
    {
        _deckRepository.CreateDB();
    }
}