using Domain;

namespace Application.DTOs;

public class GameDTO
{
    public string Name { get; set; }
    public bool Result { get; set; }
    public User User { get; set; }
    public ModularEncounter ModularEncounter { get; set; }
    public Difficulty Difficulty { get; set; }
    public Scenario Scenario { get; set; }
    public bool SchemeEmpty { get; set; }
    public bool SceondarySchemeEmpty { get; set; }
    public bool NotMinions { get; set; }
}