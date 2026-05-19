using Game.Models;

namespace Game;

internal class Game
{
    private Dictionary<string, Room> _map;
    private Actor _player;

    public Game()
    {
        InitGame();
        RunGame();
    }

    private void InitGame()
    {                                                                               // N   S  E   W
        //Room room0 = new("Your Office", "a cramped, dark office. Nothing stands out", -1, -1, 1, -1);
        //Room room1 = new("The Hallway", "a long hallway connecting different rooms",   2, 3, -1, 0);                                 // N   S  E   W
        //Room room2 = new("The Server Room", "a vast room filled with server stacks and the whirr of electronics. It's chilly",         -1, 1, -1, -1);
        //Room room3 = new("The Stairwell", "a tall staircase that goes up and down as far as you can see. Don't look down for too long", 1, -1, -1, -1);

        _map = new Dictionary<string, Room>()
        {                                                                                   //         N          S            E            W 
            { "Your Office", new Room("Your Office", "a cramped, dark office. Nothing stands out", "No Exit", "No Exit", "The Hallway", "No Exit") },
            { "The Hallway", new Room("The Hallway", "a long hallway connecting different rooms",   "The Server Room", "The Stairwell", "No Exit", "Your Office") },
            { "The Server Room", new Room("The Server Room", "a vast room filled with server stacks and the whirr of electronics. It's chilly", "No Exit", "The Hallway", "No Exit", "No Exit") },
            { "The Stairwell", new Room("The Stairwell", "a tall staircase that goes up and down as far as you can see. Don't look down for too long", "The Hallway", "No Exit", "No Exit", "No Exit") }
        };

        //_map = new Room[4];

        //_map[0] = room0;
        //_map[1] = room1;
        //_map[2] = room2;
        //_map[3] = room3;

        _player = new("You", "The Player", _map["Your Office"]);
    }
    private void RunGame()
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

    private string RunInput(string userInput)
    {
        char[] delims = [' ', '.'];
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

                    "────────────────────────┬───────────────────────────────────────────────────\n" +
                    " Allowed commands:  \t│ You can try to Move in the following directions:\n" +
                    "   Take [noun]      \t│   North \n" +
                    "   Drop [noun]      \t│   East \n" +
                    "   Look             \t│   South \n" +
                    "   Move [direction] \t│   West \n" +
                    "────────────────────────┴───────────────────────────────────────────────────";
            }
        }
        return output;
    }
    private string ParseInput(List<string> wordList)
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

    private string MovePlayer(string targetRoom, string direction)
    {
        string output = $"You attempt to move {direction}. \n";

        if (targetRoom.ToLower() != "no exit")
        {
            _player.Location = _map[targetRoom];
            output += $"You enter {_map[targetRoom].Name}. \n";
        }
        else
        {
            output += "There is no room in that direction. \n";
        }

        return output;
    }
    private string Look()
    {
        Room currentRoom = _player.Location;
        string possiblePaths = "";

        Dictionary<string, string> paths = new Dictionary<string, string>
        {
            {"North", currentRoom.N },
            {"South", currentRoom.S },
            {"East", currentRoom.E },
            {"West", currentRoom.W }
        };

        foreach (KeyValuePair<string, string> kvp in paths)
        {
            if (kvp.Value.ToLower() != "no exit")
            {
                possiblePaths += $"\t{kvp.Key} \n";
            }
        }

        return $"You are in {_player.Location.Name} \n" +
               $"You see {_player.Location.Description}. \n" +
               "This room has the following exits: \n" +
               $"{possiblePaths}";
    }
}
