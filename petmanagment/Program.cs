using petmanagment.Models;
using petmanagment.Models.Interface;
using petmanagment.Services;

// Estructuras de datos
List<Patient> patients = new List<Patient>();
Dictionary<int, Patient> patientDict = new Dictionary<int, Patient>();
List<Owner> owners = new List<Owner>();

// Crear servicio
PatientService patientService = new PatientService(patients, patientDict, owners);

// Mostrar título (asumiendo que ConsoleInterface.ShowTitle lo hace)
Console.WriteLine("Welcome to Pet Health Clinic");

while (true)
{
    MenuConsola.ShowMenu();
    Console.Write("Option: ");
    
    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            patientService.Register();
            break;

        case "2":
            patientService.ListPatients();
            break;

        case "3":
            Console.WriteLine("Enter the ID of the patient:");
            int idPatient = Convert.ToInt32(Console.ReadLine());
            
            bool found = false;

            foreach (var entry in patientDict)
            {
                if (entry.Key == idPatient)
                {
                    Patient pat = entry.Value;
                    Console.WriteLine("=== Patient Found ===");
                    Console.WriteLine($"ID: {pat.Id}");
                    Console.WriteLine($"Name: {pat.Name}");
                    Console.WriteLine($"Age: {pat.Age}");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Patient not found.");
            }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
        break;


        case "4":
            Console.WriteLine("Search by:");
            Console.WriteLine("1. Age");
            Console.WriteLine("2. Species");
            Console.Write("Select option: ");
            string searchOption = Console.ReadLine();

            if (searchOption == "1")
            {
                Console.Write("Enter age: ");
                if (int.TryParse(Console.ReadLine(), out int searchAge))
                {
                    patientService.SearchPatientByAgeOrSpecies(searchAge, null);
                }
                else
                {
                    Console.WriteLine("Invalid age format.");
                }
            }
            else if (searchOption == "2")
            {
                Console.Write("Enter species: ");
                string searchSpecies = Console.ReadLine();
                patientService.SearchPatientByAgeOrSpecies(null, searchSpecies);
            }
            else
            {
                Console.WriteLine("Invalid search option.");
            }
            break;
        case "5":
            MenuConsola.VeterinaryServiceMenu();
            string option1 = Console.ReadLine();
            switch (option1)
            {
                case "1":
                    Console.WriteLine("Enter the ID of the patient:");

                    /*foreach (var pat in patientDict)
                    {
                        if (idPatient == )
                        {
                            
                        }
                    }*/
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
                    
            }
            break;

        case "0":
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}
