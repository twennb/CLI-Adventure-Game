namespace Game.Models;

internal class Actor : ThingHolder
{
    public Room Location { get; private set; }

    public Actor(string name, string desc, ThingList thingList, Room room)
        : base(name, desc, thingList)
    {
        Location = room;
    }

    public void UpdateLocation (Room newLoc)
    {
        Location = newLoc;
    }
}
