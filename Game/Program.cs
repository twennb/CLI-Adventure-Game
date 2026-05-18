using Game.Models;

namespace Game;

public class Program()
{
    static readonly Room[] map = new Room[4];

    public static void Main(string[] args)
    {
        SetupMap();

        string userInput;

        Console.WriteLine("> \n");
        
        do
        {
            userInput = Console.ReadLine();

            // method to split input into verb and noun, return as list with verb in index 0 and noun in index 1
            string output = RunInput(userInput);
            // method to parse verb and noun from list
            
            Console.WriteLine(output + "\n");
        } while (userInput != "q");
    }

    public static void SetupMap()
    {
        map[0] = new("Your Office", 
            "A cramped, dark office. Nothing stands out.",
            -1, -1, 1, -1);

        map[1] = new("The Hallway", 
            "A long hallway connecting different rooms.",
            2, 3, -1, 0);

        map[2] = new("The Server Room",
            "A vast room filled with server stacks and the whirr of electronics. It's chilly.",
            -1, 1, -1, -1);

        map[3] = new("The Stairwell",
            "Stairs go up and down as far as you can see. Don't look down for too long!",
            1, -1, -1, -1);
    }

    public static string RunInput(string userInput)
    {
        char[] delims = [' ', '.' ];
        string output = "> ok\n";
        string cleanInput = userInput.Trim().ToLower();

        if (cleanInput != "q")
        {
            if (cleanInput == "")
            {
                output = $"\n> You must enter a command. \n";
            } 
            else
            {
                List<string> wordList = new(cleanInput.Split(delims, StringSplitOptions.RemoveEmptyEntries));
                output = ParseInput(wordList);
            }
        }

        return output;
    }

    public static string ParseInput(List<string> wordList)
    {
        string[] commands = ["take", "drop"];
        string[] objects = ["pen", "paper"];
        string verb;
        string noun;
        string output = "";

        if (wordList.Count != 2)
        {
            Console.WriteLine("\n> Only 2 word commands are allowed!");
        }
        else
        {
            verb = wordList[0];
            noun = wordList[1];
            bool valid = true;

            if (!commands.Contains(verb))
            {
                output += $"\n> {verb} is not a recognised command!";
                valid = false;
            }
            if (!objects.Contains(noun))
            {
                output += $"\n> {noun} is not a recognised object!";
                valid = false;
            }
            if (valid)
            {
                output += $"\n> You {verb} the {noun}.";
            }
        }

        return output;
    }
}