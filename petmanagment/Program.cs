
using petmanagment.Models;
using petmanagment.Models.Interface;
using petmanagment.Services;

List<Patient> patients = new List<Patient>();
Dictionary<int, Patient> patientDict = new Dictionary<int, Patient>();
List<Owner> owners = new List<Owner>();
int patientIdCounter = 1; // empieza desde 1

bool flag = true;

ConsoleInterface.ShowTitle("Pet Health Clinic");

while (flag)
        {
            Console.WriteLine();
            Console.WriteLine("------------ MAIN MENU ------------");
            Console.WriteLine("1. Register patient");
            Console.WriteLine("2. List patients");
            Console.WriteLine("3. Search for patient by ID");
            Console.WriteLine("4. Search for patient by age or species");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Patient newPatient = PatientService.RegisterPatient(patients, patientDict, owners, ref patientIdCounter);
                    if (newPatient == null)
                    {
                        Console.WriteLine("Failed to register new patient.");
                    }
                    // No es necesario agregar manualmente al diccionario ni lista porque ya se hizo dentro del método.
                    break;

                case "2":
                    PatientService.ListPatients(patientDict);
                    break;

                case "3":
                    Console.Write("Enter the ID of the patient: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        PatientService.SearchPatientById(patientDict, id);
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
                            PatientService.SearchPatientByAgeOrSpecies(patientDict, searchAge, null);
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
                        PatientService.SearchPatientByAgeOrSpecies(patientDict, null, searchSpecies);
                    }
                    else
                    {
                        Console.WriteLine("Invalid search option.");
                    }
                    break;

                case "5":
                    flag = false;
                    Console.WriteLine("Thanks for using the system!");
                    break;

                default:
                    Console.WriteLine("Please input a valid option, try again.");
                    break;
            }
        }