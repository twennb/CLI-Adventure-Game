namespace Game.Models;

internal class Actor : Thing
{
    public Room Location { get; set; }

    public Actor(string name, string desc, Room room)
        : base(name:name, description:desc)
    {
        Location = room;
    }
}
