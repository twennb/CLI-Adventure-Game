namespace Game.Models;

internal class Thing : CoreThing
{
    private bool CanTake { get; }

    public Thing(string name, string desc, bool canTake = true)
        : base(name, desc)
    {
        CanTake = canTake;
    }
}
