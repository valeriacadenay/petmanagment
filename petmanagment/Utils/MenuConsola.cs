namespace petmanagment.Models.Interface;

public class MenuConsola
{
    public static void ShowMenu()
    {
        ConsoleInterface.ShowTitle("Pet Health Clinic");

        Console.WriteLine("");
        Console.WriteLine("------------ MAIN MENU ------------");
        Console.WriteLine("1. Register patient");
        Console.WriteLine("2. List patients");
        Console.WriteLine("3. Search patient by ID");
        Console.WriteLine("4. Search patients by Age or Species");
        Console.WriteLine("5. Request a veterinary service");
        Console.WriteLine("0. Exit");
        Console.Write("Select an option: ");
    }

    public static void VeterinaryServiceMenu()
    {
        ConsoleInterface.ShowTitle("Veterinary Service Menu");
        Console.WriteLine("");
        Console.WriteLine("1. General Consultation");
        Console.WriteLine("2- Vaccination");
        Console.WriteLine("3. Back to the main menu");
        Console.Write("Select an option: ");
       
    }
}