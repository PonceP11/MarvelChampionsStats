using Application.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IDeckService
{
    public Deck CreateDeck(DeckDTO dto);

    public Deck GetDeckById(int Id);

    public List<Deck> GetAllDecks();

    public Deck UpdateDeck(int Id, Deck deck);

    public Deck DeleteDeck(int Id);

    public void CreateDB();
}