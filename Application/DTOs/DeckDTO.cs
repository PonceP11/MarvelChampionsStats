using Domain;

namespace Application.DTOs;

public class DeckDTO
{
    public string Name { get; set; }
    public Hero Hero { get; set; }
    public Aspect Aspect { get; set; }
    public string Color { get; set; }
    public string Url { get; set; }
}