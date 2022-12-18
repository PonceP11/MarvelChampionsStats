namespace Domain;

public class Scenario
{
    //public virtual ICollection<Game>? Games { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public int ContentId { get; set; }
    public virtual  Content? Content { get; set; }
    public string Image { get; set; }
    public string Icon { get; set; }
}