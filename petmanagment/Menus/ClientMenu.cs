using petmanagment.Services;
using petmanagment.Utils;

namespace petmanagment.Menus
{
    public static class ClientMenu
    {
        public static void Show()
        {
            bool back = false;

            while (!back)
            {
                ConsoleUI.Title("👤 CLIENT MENU");
                Console.WriteLine("1. Register new client");
                Console.WriteLine("2. Show all clients");
                Console.WriteLine("3. Search Clients by Name");
                Console.WriteLine("4. Update Client Information");
                Console.WriteLine("5. Delete Client");
                Console.WriteLine("9. Back to Main Menu");
                ConsoleUI.Separator();

                string option = ConsoleUI.ReadOption();

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
                        Console.WriteLine("→ Registering new client...");
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
                        {
                            Console.WriteLine($"Client found: {owner.Name} {owner.LastName}, Email: {owner.Email}, Phone: {owner.Phone}");

                            // 🔹 Mostrar las mascotas del cliente
                            Console.WriteLine($"\nPets of {owner.Name}:");
                            var pets = OwnerService.GetPetsByOwnerIdentification(owner.Identification);

                            if (pets.Count == 0)
                            {
                                Console.WriteLine("No pets registered for this owner.");
                            }
                            else
                            {
                                foreach (var pet in pets)
                                {
                                    Console.WriteLine($"- {pet.Name}, Species: {pet.Specie}, Age: {pet.Age} years");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Client not found.");
                        }
                        break;

                    case "4":
                        UpdateOwner.Show();
                        break;
                    case "5":
                        string idClient = ConsoleInputHelper.ReadString("Enter the client ID");
                        OwnerService.DeleteOwner(idClient);
                        break;
                    case "9":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }

                if (!back)
                    ConsoleUI.Pause();
            }
        }
    }
}