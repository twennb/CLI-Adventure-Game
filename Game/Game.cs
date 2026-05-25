using Game.Models;

namespace Game;

internal class Game
{
    private RoomList _map;
    private Actor _player;

    public Game()
    {
        InitGame();
        RunGame();
    }

    private void InitGame()
    {
        _map = new();
                                                                                                // N          S          E           W
        _map.Add(Rm.OFFICE, new Room("Your Office", "a cramped, dark office. Nothing stands out", Rm.NOEXIT, Rm.NOEXIT, Rm.HALLWAY, Rm.NOEXIT));
        _map.Add(Rm.HALLWAY, new Room("The Hallway", "a long hallway connecting different rooms", Rm.SERVER, Rm.STAIR, Rm.NOEXIT, Rm.OFFICE));// N          S           E       W
        _map.Add(Rm.SERVER, new Room("The Server Room", "a vast room filled with server stacks and the whirr of electronics. It's chilly", Rm.NOEXIT, Rm.HALLWAY, Rm.NOEXIT, Rm.NOEXIT));
        _map.Add(Rm.STAIR, new Room("The Stairwell", "a tall staircase that goes up and down as far as you can see. Don't look down for too long", Rm.HALLWAY, Rm.NOEXIT, Rm.NOEXIT, Rm.NOEXIT));

        _player = new("You", "The Player", _map[Rm.OFFICE]);
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
            output = CleanInput(userInput);

            Console.WriteLine(output);
        } while (userInput != "q");
    }

    private string CleanInput(string userInput)
    {
        char[] delims = [' ', '.'];
        string output = "ok \n";
        string cleanInput = userInput.Trim().ToLower();

        switch (cleanInput)
        {
            case "":
                return output = $"You must enter a command. \n" +
                                 "Enter 'h' for help. \n";

            case "h" or "help":
                return output = "The program reads written commands. \n" +
                                "The first word has to be a verb and forms the command itself. \n" +
                                "The second word is the noun or direction you wish to interact with. \n" +
                                "The command to Look does not need a second word. \n" +
                                "If you're not sure what to do, Look!\n" +
                                "────────────────────────┬───────────────────────────────────────────────────\n" +
                                " Allowed commands:  \t│ You can try to Move in the following directions:\n" +
                                "   Take [noun]      \t│   North \n" +
                                "   Drop [noun]      \t│   East \n" +
                                "   Look             \t│   South \n" +
                                "   Move [direction] \t│   West \n" +
                                "────────────────────────┴───────────────────────────────────────────────────\n";

            case "q" or "quit":
                return output;

            default:
                break;
        }
        
        List<string> wordList = new(cleanInput.Split(delims, StringSplitOptions.RemoveEmptyEntries));
        
        output = ParseInput(wordList);

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
                    return $"Command {verb} {wordList[1]} is not understood. \n";
            }
        }
        else
        {
            return $"I don't understand '{wordList[1]}'. \n";
        }
    }

    private string MovePlayer(Rm targetRoom, string direction)
    {
        string output = $"You attempt to move {direction}. \n";

        if (targetRoom != Rm.NOEXIT)
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

        Dictionary<string, Rm> paths = new Dictionary<string, Rm>
        {
            {"North", currentRoom.N },
            {"South", currentRoom.S },
            {"East", currentRoom.E },
            {"West", currentRoom.W }
        };

        foreach (KeyValuePair<string, Rm> kvp in paths)
        {
            if (kvp.Value != Rm.NOEXIT)
            {
                possiblePaths += $"\t{kvp.Key} : {_map[kvp.Value].Name} \n";
            }
        }

        return $"You are in {_player.Location.Name} \n" +
               $"You see {_player.Location.Description}. \n" +
               "This room has the following exits: \n" +
               $"{possiblePaths}";
    }
}
