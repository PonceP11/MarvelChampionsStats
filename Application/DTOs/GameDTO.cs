using Domain;

namespace Application.DTOs;

public class GameDTO
{
    public bool Result { get; set; }
    public int AspectId { get; set; }
    public int HeroId { get; set; }
    public int DifficultyId { get; set; }
    public int ScenarioId { get; set; }
    public bool SchemeEmpty { get; set; }
    public bool SecondarySchemeEmpty { get; set; }
    public bool NotMinions { get; set; }
}