using petmanagment.Data;
using petmanagment.Enum;
using petmanagment.Models;
using petmanagment.Repositories;

namespace petmanagment.Services;

public class ServiceVeterinaryService
{
    private static ServiceVeterinaryRepository _veterinaryService = new ServiceVeterinaryRepository();
    
    public void CreateServiceVeterinary(string servicesType,
                                        Patient patient,
                                        Veterinary veterinary,
                                        DateTime serviceDate,
                                        decimal cost,
                                        string reasonForVisit,
                                        string symptoms)
    {
        if (patient == null || veterinary == null || serviceDate == null ||
            cost <= 0 || string.IsNullOrEmpty(reasonForVisit) || string.IsNullOrEmpty(symptoms))
        {
            Console.WriteLine("Invalid input. Please provide valid service details.");
            return;
        }

        try
        {
            ServiceVeterinary newService = new ServiceVeterinary(servicesType, patient, veterinary, serviceDate, cost, reasonForVisit, symptoms);
            _veterinaryService.CreateService(newService);
            Console.WriteLine("Service created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating service: {ex.Message}");
        }
    }
    public List<ServiceVeterinary> GetServices()
    {
        try
        {
            return _veterinaryService.GetAll();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving services: {ex.Message}");
            return new List<ServiceVeterinary>();
        }   
    }
    public ServiceVeterinary? GetServiceById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
           Console.WriteLine("Invalid Id");
           return null;
        }
        try
        {
            return _veterinaryService.GetById(Guid.Parse(id));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving service: {ex.Message}");
            return null;
        }   
    }
    
    public void UpdateService(ServiceVeterinary service, string id)
    {
        if (service == null || string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid input. Please provide valid service details.");
            return;
        }

        try
        {
            _veterinaryService.UpdateService(service, id);
            Console.WriteLine("Service updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating service: {ex.Message}");
        }
    }
    public void DeleteService(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        try
        {
            _veterinaryService.Delete(Guid.Parse(id));
            Console.WriteLine("Service deleted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting service: {ex.Message}");
        }
    }
    
    public static void ScheduleService()
        {
            var availableServices = DataBase.AvailableServices;
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

        public static void ShowAllServices()
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

    