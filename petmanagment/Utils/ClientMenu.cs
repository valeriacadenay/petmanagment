using petmanagment.Models.Interface;
using petmanagment.Services;

namespace petmanagment.Utils;

public class ClientMenu
{
    public static void ShowClientMenu()
    {
        Console.WriteLine("\n--- MENU CLIENT ---");
        Console.WriteLine("1. Register a new Client");
        Console.WriteLine("2. List Clients");
        Console.WriteLine("3. Search Clients by Name");
        Console.WriteLine("4. Update Client Information");
        Console.WriteLine("5. Delete Client");
        Console.WriteLine("0. return to main menu");
        Console.WriteLine("Enter a option ");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                string name = ConsoleInputHelper.ReadString("Enter client name");
                string lastName = ConsoleInputHelper.ReadString("Enter client last name");
                string identification = ConsoleInputHelper.ReadString("Enter identification");
                string email = ConsoleInputHelper.ReadString("Enter email");
                string phone = ConsoleInputHelper.ReadString("Enter phone number");
                int age = ConsoleInputHelper.ReadInt("Enter age");

                OwnerService.CreateOwner(name, lastName, identification, email, phone, age);
                ConsoleInputHelper.ReadString("Press enter to continue");
                break;
            case "2":
                var owners = OwnerService.GetOwners();
                if (owners.Count == 0)
                {
                    Console.WriteLine("No clients found.");
                }
                else
                {
                    Console.WriteLine("Clients List:");
                    foreach (var own in owners)
                    {
                        Console.WriteLine($"- {own.Name} {own.LastName}, Email: {own.Email}, Phone: {own.Phone}");
                    }
                }
                break;
            case "3":
                string searchName = ConsoleInputHelper.ReadString("Enter client name to search");
                var owner = OwnerService.GetOwnerByName(searchName);

                if (owner != null)
                    Console.WriteLine($"Client found: {owner.Name} {owner.LastName}, Email: {owner.Email}, Phone: {owner.Phone}");
                else
                    Console.WriteLine("Client not found.");
                break;
            case "4":
                ShowUpdateOwnerMenu.Show();
                break;
            case "5":
                string idClient = ConsoleInputHelper.ReadString("Enter the client ID");
                OwnerService.DeleteOwner(idClient);
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