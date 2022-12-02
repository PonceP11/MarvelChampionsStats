namespace Domain;

public class Game
{
    public int Id { get; set; }
    public bool result { get; set; }
    public User User { get; set; }
    public ModularEncounter ModularEncounter { get; set; }
    public Difficulty Difficulty { get; set; }
    public Scenario Scenario { get; set; }
    public bool SchemeEmpty { get; set; }
    public bool SceondarySchemeEmpty { get; set; }
    public bool NotMinions { get; set; }
}