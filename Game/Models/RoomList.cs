namespace Game.Models;

internal class RoomList : Dictionary<Rm, Room>
{
    public RoomList()
    {
        
    }

    public string DescribeRoom(Rm rm)
    {
        string desc = this[rm].Description;

        return desc;
    }
}
