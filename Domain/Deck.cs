namespace Domain;

public class Deck
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Hero Hero { get; set; }
    public Aspect Aspect { get; set; }
    public string Url { get; set; }
}