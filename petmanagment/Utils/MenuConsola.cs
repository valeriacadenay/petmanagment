using petmanagment.Services;

namespace petmanagment.Models.Interface;

public class MenuConsola
{
    public static void ShowMenu()
    {
        ConsoleInterface.ShowTitle("Pet Health Clinic");

        Console.WriteLine("");
        Console.WriteLine("------------ MAIN MENU ------------");
        Console.WriteLine("1. Register a new Client");
        Console.WriteLine("2. List Clients");
        Console.WriteLine("3. Search Clients by Name");
        Console.WriteLine("4. Update Client Information");
        Console.WriteLine("5. Delete Client");
        Console.WriteLine("6. Register a new Patient");
        Console.WriteLine("7. List Patients");
        Console.WriteLine("8. Update Patient Information");
        Console.WriteLine("10. Search Patients by ID");
        Console.WriteLine("11. Delete Patient");
        Console.WriteLine("12. Register a new Veterinary");
        Console.WriteLine("13. List Veterinaries");
        Console.WriteLine("14. Search Veterinaries by ID");
        Console.WriteLine("15. Update Veterinary Information");
        Console.WriteLine("16. Delete Veterinary");
        Console.WriteLine("17. Request a veterinary service");
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
                string name = ConsoleInputHelper.ReadString("Enter client name");
                string lastName = ConsoleInputHelper.ReadString("Enter client last name");
                string identification = ConsoleInputHelper.ReadString("Enter identification");
                string email = ConsoleInputHelper.ReadString("Enter email");
                string phone = ConsoleInputHelper.ReadString("Enter phone number");
                int age = ConsoleInputHelper.ReadInt("Enter age");

                OwnerService.CreateOwner(name, lastName, identification, email, phone, age);
                break;
            case "2":
                OwnerService.GetOwners();
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
                string id = ConsoleInputHelper.ReadString("Enter the client ID");
                OwnerService.DeleteOwner(id);
                break;
                
                
            
        }
    }
    
}