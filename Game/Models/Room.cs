namespace Game.Models;

internal class Room : ThingHolder
{
    public Rm N { get; }
    public Rm S { get; }
    public Rm E { get; }
    public Rm W { get; }

    public Room (string name, string desc, ThingList thingList, Rm n, Rm s, Rm e, Rm w)
        : base (name, desc, false, thingList)
    {
        N = n;
        S = s;
        E = e;
        W = w;
    }

    public string Describe()
    {
        return $"{Name}. It is {Description}.";
    }
}
