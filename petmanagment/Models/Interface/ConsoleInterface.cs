namespace petmanagment.Models.Interface;

public class ConsoleInterface
{
    public static void ShowTitle(string title)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("======================================================");
        Console.WriteLine($"                 {title.ToUpper()}");
        Console.WriteLine("======================================================");
        Console.ResetColor();
    }

    public static void ShowFoot(string foot)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine();
        Console.WriteLine("======================================================");
        Console.WriteLine($"           {foot}");
        Console.WriteLine("======================================================");
        Console.ResetColor();
    }

    public static void ShowSeparator()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("-------------------------------------------------");
        Console.ResetColor();
    }
}