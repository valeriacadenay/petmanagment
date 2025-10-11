using petmanagment.Models.Interface;
using petmanagment.Services;

namespace petmanagment.Utils;

public class MenuConsola
{
    public static void ShowMenu()
    {
        ConsoleInterface.ShowTitle("Pet Health Clinic");

        Console.WriteLine("");
        Console.WriteLine("------------ MAIN MENU ------------");
        Console.WriteLine("1. Menu Client - Owner");
        Console.WriteLine("2. Menu Patient - Pet");
        Console.WriteLine("3. Menu Veterinary");
        Console.WriteLine("0. Exit");
        Console.Write("Select an option: ");

        string option = Console.ReadLine();
        ConsoleInterface.ShowSeparator();

        switch (option)
        {
            case "0":
                Console.WriteLine("Exiting the program. Goodbye!");
                Environment.Exit(0);
                break;
            case "1":
                ClientMenu.ShowClientMenu();
                break;
            case "2":
                PatientMenu.ShowMenuPatient();
                break;
            case "3":
                VeterinaryMenu.VeterinaryShowMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    } 
}