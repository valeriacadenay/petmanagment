using petmanagment.Services;

namespace petmanagment.Models.Interface;

public class ShowUpdatePatientMenu
{
    public static void Show()
    {
        Console.WriteLine("\n--- UPDATE PATIENT INFORMATION ---");
        string id = ConsoleInputHelper.ReadString("Enter Patient ID");

        Console.WriteLine("Select the field you want to update:");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Age");
        Console.WriteLine("3. Specie");
        Console.WriteLine("4. Race");
        Console.WriteLine("0. Return to Main Menu");
        string option = Console.ReadLine();
        switch (option)
        {
            case "1":
                string newName = ConsoleInputHelper.ReadString("Enter new Name");
                PatientService.UpdatePatientName(id, newName);
                break;
            case "2":
                int newAge = ConsoleInputHelper.ReadInt("Enter new Age");
                PatientService.UpdatePatientAge(id, newAge);
                break;
            case "3":
                string newSpecie = ConsoleInputHelper.ReadString("Enter new Specie");
                PatientService.UpdatePatientSpecie(id, newSpecie);
                break;
            case "4":
                string newRace = ConsoleInputHelper.ReadString("Enter the new race of the pet");
                break;
            case "0":
                Console.WriteLine("Returning to Main Menu...");
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

}