using Game.Models;
using System.Xml;

namespace Game;

public class Program()
{
    private static Room[] _map;
    private static Actor _player;
    
    public static void Main(string[] args)
    {
        InitGame();
        RunGame();
    }

    private static void InitGame()
    {
        Room room0 = new("Your Office",
            "a cramped, dark office. Nothing stands out",
            -1, -1, 1, -1);

        Room room1 = new("The Hallway",
            "a long hallway connecting different rooms",
            2, 3, -1, 0);

        Room room2 = new("The Server Room",
            "a vast room filled with server stacks and the whirr of electronics. It's chilly",
            -1, 1, -1, -1);

        Room room3 = new("The Stairwell",
            "a tall staircase that goes up and down as far as you can see. Don't look down for too long",
            1, -1, -1, -1);

        _map = new Room[4];

        _map[0] = room0;
        _map[1] = room1;
        _map[2] = room2;
        _map[3] = room3;

        _player = new("You", "The Player", _map[0]);
    }
    private static void RunGame()
    {
        string userInput = "";
        string output = "";
        string message = "Welcome to this exciting office adventure game!\n\n" +
                         $"You are in {_player.Location.Name}.\n" +
                         $"It is {_player.Location.Description}.\n";

        Console.WriteLine(message);

        do
        {
            Console.Write("> ");

            userInput = Console.ReadLine();
            output = RunInput(userInput);

            Console.WriteLine(output);
        } while (userInput != "q");
    }

    private static string RunInput(string userInput)
    {
        char[] delims = [' ', '.' ];
        string output = "ok \n";
        string cleanInput = userInput.Trim().ToLower();

        if (cleanInput != "q")
        {
            if (cleanInput != "h") 
            { 
                if (cleanInput != "")
                {
                    List<string> wordList = new(cleanInput.Split(delims, StringSplitOptions.RemoveEmptyEntries));
                    output = ParseInput(wordList);
                }
                else
                {
                    output = $"You must enter a command. \n" +
                        "Enter 'h' for help. \n";
                }
            }
            else
            {
                output = "The program reads written commands. \n" +
                    "The first word has to be a verb and forms the command itself. \n" +
                    "The second word is the noun or direction you wish to interact with. \n" +
                    "The command to Look does not need a second word. \n" +
                    "Allowed commands: \n" +
                    "\tTake [noun] \n" +
                    "\tDrop [noun] \n" +
                    "\tLook \n" +
                    "\tMove [direction] \n" +
                    "You can try to Move in the following directions: \n" +
                    "\t N \n" +
                    "\t E \n" +
                    "\t S \n" +
                    "\t W \n" +
                    "Enter 'q' at any time to quit. \n";
            }
        }
        return output;
    }
    private static string ParseInput(List<string> wordList)
    {
        string[] commands = ["take", "drop", "move", "look"];
        string[] objects = ["pen", "paper"];
        string[] directions = ["n", "north", "s", "south", "e", "east", "w", "west"];
        
        string verb;
        string noun;
        string direction;
        
        verb = wordList[0];
        
        if (!commands.Contains(verb))
        {
            return $"{verb} is not a recognised command! Enter 'h' for help. \n";
        }
         
        if (wordList.Count == 1 && verb == "look")
        {
            return Look();
        }
        
        if (objects.Contains(wordList[1]))
        {
            noun = wordList[1];

            return $"You {verb} the {noun} \n";
        }
        else if (directions.Contains(wordList[1]))
        {
            direction = wordList[1];

            switch (direction)
            {
                case "n" or "north":
                    return MovePlayer(_player.Location.N, "North");
                case "s" or "south":
                    return MovePlayer(_player.Location.S, "South");
                case "e" or "east":
                    return MovePlayer(_player.Location.E, "East");
                case "w" or "west":
                    return MovePlayer(_player.Location.W, "West");
                default:
                    return "Command is not understood. \n";
            }
        }
        else
        {
            return $"I don't understand '{wordList[1]}'. \n";
        }
    }

    private static string MovePlayer(int targetRoom, string direction)
    {
        string output = $"You move {direction}. ";

        if (targetRoom != -1)
        {
            _player.Location = _map[targetRoom];
            output += $"You enter {_map[targetRoom].Name}. \n";
        }
        else
        {
            output = "There is no room in that direction. \n";
        }

        return output;
    }
    private static string Look()
    {
        Room currentRoom = _player.Location;
        string possiblePaths = "";
        
        Dictionary<string, int> paths = new Dictionary<string, int>
        {
            {"North", currentRoom.N },
            {"South", currentRoom.S },
            {"East", currentRoom.E },
            {"West", currentRoom.W }
        };

        foreach (KeyValuePair<string, int> kvp in paths)
        {
            if (kvp.Value != -1)
            {
                possiblePaths += $"\t{kvp.Key} \n";
            }
        }

        return $"You see {_player.Location.Description}. \n" +
                "This room has the following exits: \n" +
                $"{possiblePaths}";
    }
}