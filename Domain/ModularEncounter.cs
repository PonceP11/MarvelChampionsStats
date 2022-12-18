namespace Domain;

public class ModularEncounter
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual  Content Content { get; set; }
    public string Image { get; set; }
}