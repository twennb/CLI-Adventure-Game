namespace Game.Models;

internal class ThingList : List<Thing>
{
    public string DebugList()
    {
        string output = "";

        if (this.Count == 0)
        {
            return "There are no items in this list!";
        }
        else
        {
            foreach (Thing item in this)
            {
                output += $"{item.Name} is {item.Description} \r\n";
            }
        }

        return output;
    }
}
