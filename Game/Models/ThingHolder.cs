namespace Game.Models;

internal class ThingHolder : CoreThing
{
    public ThingList Things { get; }

    public ThingHolder(string name, string desc, ThingList thingList)
        : base(name, desc)
    {
        Things = thingList;
    }

    public void AddThing(Thing thing)
    {
        Things.Add(thing);
    }

    public string Debug()
    {
        return $"Name: {Name}, Description: {Description}. \r\n" +
            $"Contains: {Things.DebugList()}";
    }
}