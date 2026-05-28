namespace Game.Models;

internal class Treasure : Thing
{
    public int Value { get; }

    public Treasure(string name, string desc, int value)
        : base(name, desc)
    {
        Value = value;
    }
}

