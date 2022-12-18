namespace Domain;

public class Deck
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual Hero Hero { get; set; }
    public virtual Aspect Aspect { get; set; }
    public string Url { get; set; }
}