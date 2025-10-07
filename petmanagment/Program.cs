using petmanagment.Models;
using petmanagment.Models.Interface;
using petmanagment.Services;

// Estructuras de datos
List<Patient> patients = new List<Patient>();
Dictionary<int, Patient> patientDict = new Dictionary<int, Patient>();
List<Owner> owners = new List<Owner>();

// Contador para IDs
int patientIdCounter = 1;

// Mostrar título
Console.WriteLine("Welcome to Pet Health Clinic");

while (true)
{
    MenuConsola.ShowMenu();
    Console.Write("Option: ");
    
    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            // Pasar las colecciones y el contador para registrar
            PatientService.RegisterPatient(patients, patientDict, owners, ref patientIdCounter);
            break;

        case "2":
            PatientService.ListPatients(patients);
            break;

        case "3":
            Console.WriteLine("Enter the ID of the patient:");
            if (int.TryParse(Console.ReadLine(), out int idPatient))
            {
                if (patientDict.TryGetValue(idPatient, out Patient pat))
                {
                    Console.WriteLine("=== Patient Found ===");
                    Console.WriteLine($"ID: {idPatient}");
                    Console.WriteLine($"Name: {pat.Name}");
                    Console.WriteLine($"Age: {pat.Age}");
                }
                else
                {
                    Console.WriteLine("Patient not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
            break;
/*
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
                    PatientService.SearchPatientByAgeOrSpecies(patients, searchAge, null);
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
                PatientService.SearchPatientByAgeOrSpecies(patients, null, searchSpecies);
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
                    if (int.TryParse(Console.ReadLine(), out int vetPatientId))
                    {
                        if (patientDict.TryGetValue(vetPatientId, out Patient vetPat))
                        {
                            // Aquí va la lógica que deseas implementar
                            Console.WriteLine($"Performing veterinary service for patient {vetPat.Name} {vetPat.LastName}");
                        }
                        else
                        {
                            Console.WriteLine("Patient not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID format.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
            break;
            */

        case "0":
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}
