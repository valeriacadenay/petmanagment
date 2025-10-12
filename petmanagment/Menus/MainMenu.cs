
using petmanagment.Utils;

namespace petmanagment.Menus;

public static class MainMenu
{
    public static void Show()
    {
        bool exit = false;

        while (!exit)
        {
            ConsoleUI.Title("🐾 PET HEALTH CLINIC 🏥");
            Console.WriteLine("1. Client Menu");
            Console.WriteLine("2. Patient Menu");
            Console.WriteLine("3. Veterinary Menu");
            Console.WriteLine("4. Services ");
            Console.WriteLine("0. Exit");
            ConsoleUI.Separator();

            string option = ConsoleUI.ReadOption();

            switch (option)
            {
                case "1":
                    ClientMenu.Show();
                    break;
                case "2":
                    PatientMenu.Show();
                    break;
                case "3":
                    VeterinaryMenu.Show();
                    break;
                case "4":
                    ServiceVeterinaryMenu.ShowServiceMenu();
                    break;
                case "0":
                    Console.WriteLine("\nGoodbye! 👋");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    ConsoleUI.Pause();
                    break;
            }
        }
    }
}