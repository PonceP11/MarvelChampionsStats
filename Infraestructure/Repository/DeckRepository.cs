using Application.Interfaces;
using Domain;

namespace Infraestructure;

public class DeckRepository : IDeckRepository
{
    private DBContext _deckDbContext;

    public DeckRepository(DBContext context)
    {
        _deckDbContext = context;
    }
    public Deck CreateDeck(Deck deck)
    {
        _deckDbContext.DeckTable.Add(deck);
        _deckDbContext.SaveChanges();
        return deck;
    }

    public Deck GetDeckById(int Id)
    {
        return _deckDbContext.DeckTable.Find(Id);
    }

    public List<Deck> GetAllDecks()
    {
        return _deckDbContext.DeckTable.ToList();
    }

    public Deck UpdateDeck(int Id, Deck deck)
    {
        _deckDbContext.DeckTable.Update(deck);
        _deckDbContext.SaveChanges();
        return deck;
    }

    public Deck DeleteDeck(int Id)
    {
        var deckToDelete = _deckDbContext.DeckTable.Find(Id) ?? throw new KeyNotFoundException();
        _deckDbContext.DeckTable.Remove(deckToDelete);
        _deckDbContext.SaveChanges();
        return deckToDelete;
    }

    public void CreateDB()
    {
        _deckDbContext.Database.EnsureDeleted();
        _deckDbContext.Database.EnsureCreated();
    }
}