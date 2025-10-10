namespace petmanagment.Models.Interface;

public class ConsoleInputHelper
{
    public static string ReadString(string message)
    {
        Console.Write(message + ": ");
        string input = Console.ReadLine();
        while (string.IsNullOrEmpty(input))
        {
            Console.Write("Input cannot be empty. Please try again: ");
            input = Console.ReadLine();
        }
        return input;
    }

    public static int ReadInt(string message)
    {
        Console.Write(message + ": ");
        string input = Console.ReadLine();
        int value;
        while (!int.TryParse(input, out value))
        {
            Console.Write("Invalid number. Please try again: ");
            input = Console.ReadLine();
        }
        return value;
    }
}
