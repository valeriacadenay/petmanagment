using petmanagment.Models;
using petmanagment.Data;
using petmanagment.Services;

namespace petmanagment.Utils
{
    public static class ServiceVeterinaryMenu
    {

        public static void ShowServiceMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("----- VETERINARY SERVICES MENU -----");
                Console.WriteLine("1. Programar nuevo servicio");
                Console.WriteLine("2. Ver servicios programados");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("Selecciona una opción: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ServiceVeterinaryService.ScheduleService();
                        break;
                    case "2":
                        ServiceVeterinaryService.ShowAllServices();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Presiona una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

    }
}
