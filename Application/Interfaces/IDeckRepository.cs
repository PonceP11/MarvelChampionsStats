using Domain;

namespace Application.Interfaces;

public interface IDeckRepository
{
    public Deck CreateDeck(Deck deck);

    public Deck GetDeckById(int Id);

    public List<Deck> GetAllDecks();

    public Deck UpdateDeck(int Id, Deck deck);

    public Deck DeleteDeck(int Id);

    public void CreateDB();
}