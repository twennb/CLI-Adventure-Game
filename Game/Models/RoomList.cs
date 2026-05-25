namespace Game.Models;

internal class RoomList : Dictionary<Rooms, Room>
{
    public RoomList()
    {
        
    }

    public string DescribeRoom(Rooms rm)
    {
        string desc = this[rm].Description;

        return desc;
    }
}
