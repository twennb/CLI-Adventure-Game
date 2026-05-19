namespace Game.Models;

internal class Room : Thing
{
    public int N { get; }
    public int S { get; }
    public int E { get; }
    public int W { get; }

    public Room (string name, string desc, int n, int s, int e, int w)
        : base (name:name, description:desc)
    {
        N = n;
        S = s;
        E = e;
        W = w;
    }
}
