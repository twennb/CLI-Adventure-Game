namespace Game.Models;

internal class Room : Thing
{
    public string N { get; }
    public string S { get; }
    public string E { get; }
    public string W { get; }

    public Room (string name, string desc, string n, string s, string e, string w)
        : base (name:name, description:desc)
    {
        N = n;
        S = s;
        E = e;
        W = w;
    }
}
