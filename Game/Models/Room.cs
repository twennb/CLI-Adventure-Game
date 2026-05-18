namespace Game.Models;

internal class Room
{
    private string Name { get; set; }
    private string Description { get; set; }
    private int N { get; set; }
    private int S { get; set; }
    private int E { get; set; }
    private int W { get; set; }

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
