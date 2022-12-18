namespace Domain;

public class Game
{
    public int Id { get; set; }
    public bool result { get; set; }
    public virtual Aspect? Aspect { get; set; }
    public int AspectId { get; set; }
    public virtual Hero? Hero { get; set; }
    public int HeroId { get; set; }
    public virtual Difficulty? Difficulty { get; set; }
    public int DifficultyId { get; set; }
    public virtual Scenario? Scenario { get; set; }
    public int ScenarioId { get; set; }
    public bool SchemeEmpty { get; set; }
    public bool SecondarySchemeEmpty { get; set; }
    public bool NotMinions { get; set; }
}