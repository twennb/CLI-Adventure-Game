namespace Game.Models;

internal class RoomList : Dictionary<Rm, Room>
{
    public RoomList()
    {
        
    }

    public string DescribeRoom(Rm rm)
    {
        return this[rm].Describe();
    }

    public string DebugMap()
    {
        string output = "";

        if (this.Count == 0)
        {
            return "There are no rooms in the map!";
        }
        else
        {
            foreach(KeyValuePair<Rm, Room> kvp in this)
            {
                output += $"{kvp.Value.Describe()} \r\n";
            }
        }
            // otherwise run each rooms Describe method in turn.

            return output;
    }
}
