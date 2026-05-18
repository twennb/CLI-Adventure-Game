namespace Game.Models;

internal class Room
{
    public string Name { get; }
    public string Description { get; }
    public int N { get; }
    public int S { get; }
    public int E { get; }
    public int W { get; }

    public Room (string name, string desc, int n, int s, int e, int w)
    {
        Name = name;
        Description = desc;
        N = n;
        S = s;
        E = e;
        W = w;
    }
}
