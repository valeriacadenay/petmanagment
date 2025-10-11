using petmanagment.Models.Interface;
using petmanagment.Services;

namespace petmanagment.Utils;

public class PatientMenu
{
    public static void ShowMenuPatient()
    {
        Console.WriteLine("\n--- MENU PET ---");
        Console.WriteLine("1. Register a new Pet");
        Console.WriteLine("2. List Pets");
        Console.WriteLine("3. Search Pets by Name");
        Console.WriteLine("4. Search Pets by ID");
        Console.WriteLine("5. Update Pet Information");
        Console.WriteLine("6. Delete Pet");
        Console.WriteLine("0. Return to Main Menu");
        Console.WriteLine("Enter a option ");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                string petName = ConsoleInputHelper.ReadString("Enter pet name");
                int petAge = ConsoleInputHelper.ReadInt("Enter pet age");
                string petSpecie = ConsoleInputHelper.ReadString("Enter pet specie");
                string petRace = ConsoleInputHelper.ReadString("Enter the pet race:");
                string ownerId = ConsoleInputHelper.ReadString("Enter the owner Identification:");

                PatientService.CreatePatient(petName, petAge, petSpecie, petRace, ownerId);
                break;
            case "2":
                var patients = PatientService.GetAllPatients();
                if (patients.Count == 0)
                {
                    Console.WriteLine("No clients found.");
                }
                else
                {
                    Console.WriteLine("Clients List:");
                    foreach (var patient in patients)
                    {
                        Console.WriteLine($"- {patient.Name} , Specie: {patient.Specie}, Race:{patient.Race},  Age: {patient.Age}, Owner Identification : {patient.OwnerIdentification}");
                    }
                }
                break;
            case "3":
                string patientName = ConsoleInputHelper.ReadString("Enter patient name to search");
                PatientService.GetPatientByName(patientName);
                if (patientName != null)
                {
                    Console.WriteLine($"Patient found: {patientName}");
                }
                else
                {
                    Console.WriteLine("Patient not found.");
                }
                break;
            case "4":
                string idPet = ConsoleInputHelper.ReadString("Enter Patient ID to search");
                if (idPet != null)
                {
                    Console.WriteLine($"Patient found: {idPet}");
                }
                else
                {
                    Console.WriteLine("Patient not found.");
                }
                break;
            case "5":
                ShowUpdatePatientMenu.Show();
                break;
            case"6":
                string idPatient = ConsoleInputHelper.ReadString("Enter the patient ID to delete:");
                PatientService.DeletePatient(idPatient);
                break;
            case "0":
                Console.WriteLine("Returning to Main Menu...");
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
}