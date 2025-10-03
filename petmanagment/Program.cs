
using petmanagment.Models;
using petmanagment.Models.Interface;
using petmanagment.Services;

// Estructuras de datos
List<Patient> patients = new List<Patient>();
Dictionary<int, Patient> patientDict = new Dictionary<int, Patient>();
List<Owner> owners = new List<Owner>();
int patientIdCounter = 1;

// Crear instancia de servicio con las estructuras compartidas
PatientService patientService = new PatientService(patients, patientDict, owners, patientIdCounter);

ConsoleInterface.ShowTitle("Pet Health Clinic");

while (true)
        {
            MenuConsola.ShowMenu();
            
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    patientService.Register(); // Usa la instancia
                    break;

                case "2":
                    patientService.ListPatients();
                    break;

                case "3":
                    Console.Write("Enter the ID of the patient: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        patientService.SearchPatientById(id);
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
                            break;
                    }
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Please enter a valid option");
                    break;


            }
        }