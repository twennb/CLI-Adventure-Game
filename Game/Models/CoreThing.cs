namespace Game.Models;

internal class CoreThing
{
    public string Name { get; set; }
    public string Description { get; set; }

    public CoreThing(string name, string description)
    {
        Name = name;
        Description = description;
    }

}
