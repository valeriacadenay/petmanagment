using petmanagment.Models;
using petmanagment.Data;

namespace petmanagment.Utils
{
    public static class ServiceVeterinaryMenu
    {
        private static List<string> availableServices = new List<string>
        {
            "Vacunación",
            "Consulta General",
            "Cirugía",
            "Limpieza Dental",
            "Atención de Emergencia"
        };

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
                        ScheduleService();
                        break;
                    case "2":
                        ShowAllServices();
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

        private static void ScheduleService()
        {
            Console.Clear();
            Console.WriteLine("----- PROGRAMAR NUEVO SERVICIO -----");

            // 1️⃣ Tipo de servicio
            Console.WriteLine("Selecciona el tipo de servicio:");
            for (int i = 0; i < availableServices.Count; i++)
                Console.WriteLine($"{i + 1}. {availableServices[i]}");

            Console.Write("Opción: ");
            int serviceIndex;
            while (!int.TryParse(Console.ReadLine(), out serviceIndex) || serviceIndex < 1 || serviceIndex > availableServices.Count)
            {
                Console.Write("Opción inválida. Intenta de nuevo: ");
            }
            string selectedService = availableServices[serviceIndex - 1];

            // 2️⃣ Veterinario
            var veterinaries = DataBase.Veterinarys;
            Console.WriteLine("\nSelecciona el veterinario:");
            for (int i = 0; i < veterinaries.Count; i++)
                Console.WriteLine($"{i + 1}. {veterinaries[i].Name} {veterinaries[i].LastName}");

            Console.Write("Opción: ");
            int vetIndex;
            while (!int.TryParse(Console.ReadLine(), out vetIndex) || vetIndex < 1 || vetIndex > veterinaries.Count)
            {
                Console.Write("Opción inválida. Intenta de nuevo: ");
            }
            var selectedVet = veterinaries[vetIndex - 1];

            // 3️⃣ Paciente
            var patients = DataBase.Patients;
            Console.WriteLine("\nSelecciona el paciente:");
            for (int i = 0; i < patients.Count; i++)
                Console.WriteLine($"{i + 1}. {patients[i].Name}");

            Console.Write("Opción: ");
            int patIndex;
            while (!int.TryParse(Console.ReadLine(), out patIndex) || patIndex < 1 || patIndex > patients.Count)
            {
                Console.Write("Opción inválida. Intenta de nuevo: ");
            }
            var selectedPatient = patients[patIndex - 1];

            // 4️⃣ Fecha y hora
            DateTime date;
            Console.Write("\nIngresa la fecha (YYYY-MM-DD): ");
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.Write("Formato inválido. Intenta nuevamente (YYYY-MM-DD): ");
            }

            TimeSpan time;
            Console.Write("Ingresa la hora (HH:mm): ");
            while (!TimeSpan.TryParse(Console.ReadLine(), out time))
            {
                Console.Write("Formato inválido. Intenta nuevamente (HH:mm): ");
            }

            DateTime appointmentDate = date.Date + time;

            // Validar cruce de horarios
            var services = DataBase.Services;
            bool conflict = services.Any(s =>
                s.Veterinary.Name == selectedVet.Name &&
                s.ServiceDate == appointmentDate);

            if (conflict)
            {
                Console.WriteLine("\n⚠️ Ese veterinario ya tiene una cita a esa hora. Elige otra hora.");
                Console.ReadKey();
                return;
            }

            // 5️⃣ Coste, motivo, síntomas
            Console.Write("Costo del servicio: ");
            decimal cost;
            while (!decimal.TryParse(Console.ReadLine(), out cost))
            {
                Console.Write("Valor inválido. Ingresa un número: ");
            }

            Console.Write("Motivo de la visita: ");
            string reason = Console.ReadLine();

            Console.Write("Síntomas: ");
            string symptoms = Console.ReadLine();

            // Crear y guardar servicio
            var service = new ServiceVeterinary(selectedService,
                selectedPatient,
                selectedVet,
                appointmentDate,
                cost,
                reason,
                symptoms);

            services.Add(service);

            Console.WriteLine("\n✅ Servicio agendado correctamente.");
            Console.ReadKey();
        }

        private static void ShowAllServices()
        {
            Console.Clear();
            Console.WriteLine("----- SERVICIOS PROGRAMADOS -----");

            var services = DataBase.Services;

            if (services.Count == 0)
            {
                Console.WriteLine("No hay servicios registrados todavía.");
            }
            else
            {
                foreach (var s in services)
                {
                    Console.WriteLine($"Servicio: {s.ServiceType}");
                    Console.WriteLine($"Veterinario: {s.Veterinary.Name} {s.Veterinary.LastName}");
                    Console.WriteLine($"Paciente: {s.Patient.Name}");
                    Console.WriteLine($"Motivo: {s.ReasonForVisit}");
                    Console.WriteLine($"Síntomas: {s.Symptoms}");
                    Console.WriteLine($"Fecha: {s.ServiceDate}");
                    Console.WriteLine($"Costo: {s.Cost:C}");
                    Console.WriteLine("-----------------------------------");
                }
            }

            Console.WriteLine("\nPresiona cualquier tecla para regresar...");
            Console.ReadKey();
        }
    }
}
