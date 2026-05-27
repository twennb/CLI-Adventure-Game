namespace Game.Models;

internal class Room : Thing
{
    public Rm N { get; }
    public Rm S { get; }
    public Rm E { get; }
    public Rm W { get; }

    public Room (string name, string desc, Rm n, Rm s, Rm e, Rm w)
        : base (name:name, description:desc)
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
