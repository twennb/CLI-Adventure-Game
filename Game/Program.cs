public class Program()
{
    public static void Main(string[] args)
    {
        string userInput;

        do
        {
            Console.WriteLine("> ");
            userInput = Console.ReadLine();
            Console.WriteLine("You wrote '" + userInput + "'.");
        } while (userInput != "q");
    }
}