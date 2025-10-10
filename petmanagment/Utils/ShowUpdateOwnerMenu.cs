using petmanagment.Services;

namespace petmanagment.Models.Interface;

public class ShowUpdateOwnerMenu
{
    public static void Show()
    {
        Console.WriteLine("\n--- UPDATE CLIENT INFORMATION ---");
        string id = ConsoleInputHelper.ReadString("Enter Client ID");

        Console.WriteLine("Select the field you want to update:");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Last Name");
        Console.WriteLine("3. Email");
        Console.WriteLine("4. Phone");
        Console.WriteLine("0. Return to Main Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                string newName = ConsoleInputHelper.ReadString("Enter new Name");
                OwnerService.UpdateOwnerName(id, newName);
                break;
            case "2":
                string newLastName = ConsoleInputHelper.ReadString("Enter new Last Name");
                OwnerService.UpdateOwnerLastName(id, newLastName);
                break;
            case "3":
                string newEmail = ConsoleInputHelper.ReadString("Enter new Email");
                OwnerService.UpdateOwnerEmail(id, newEmail);
                break;
            case "4":
                string newPhone = ConsoleInputHelper.ReadString("Enter new Phone Number");
                OwnerService.UpdateOwnerPhone(id, newPhone);
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