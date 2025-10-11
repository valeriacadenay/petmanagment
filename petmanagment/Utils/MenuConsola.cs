using petmanagment.Models.Interface;
using petmanagment.Services;

namespace petmanagment.Utils;

public class MenuConsola
{
    public static void ShowMenu()
    {
        ConsoleInterface.ShowTitle("Pet Health Clinic");

        Console.WriteLine("");
        Console.WriteLine("------------ MAIN MENU ------------");
        Console.WriteLine("1. Register a new Client");
        Console.WriteLine("2. List Clients");
        Console.WriteLine("3. Search Clients by Name");
        Console.WriteLine("4. Update Client Information");
        Console.WriteLine("5. Delete Client");
        Console.WriteLine("6. Register a new Patient");
        Console.WriteLine("7. List Patients");
        Console.WriteLine("8. Update Patient Information");
        Console.WriteLine("9. Search Patients by Name");
        Console.WriteLine("10. Search Patients by ID");
        Console.WriteLine("11. Delete Patient");
        Console.WriteLine("12. Register a new Veterinary");
        Console.WriteLine("13. List Veterinaries");
        Console.WriteLine("14. Search Veterinaries by ID");
        Console.WriteLine("15. Update Veterinary Information");
        Console.WriteLine("16. Delete Veterinary");
        Console.WriteLine("17. Request a veterinary service");
        Console.WriteLine("0. Exit");
        Console.Write("Select an option: ");

        string option = Console.ReadLine();
        //ConsoleInterface.ShowSeparator();

        switch (option)
        {
            case "0":
                Console.WriteLine("Exiting the program. Goodbye!");
                Environment.Exit(0);
                break;
            case "1":
                string name = ConsoleInputHelper.ReadString("Enter client name");
                string lastName = ConsoleInputHelper.ReadString("Enter client last name");
                string identification = ConsoleInputHelper.ReadString("Enter identification");
                string email = ConsoleInputHelper.ReadString("Enter email");
                string phone = ConsoleInputHelper.ReadString("Enter phone number");
                int age = ConsoleInputHelper.ReadInt("Enter age");

                OwnerService.CreateOwner(name, lastName, identification, email, phone, age);
                ConsoleInputHelper.ReadString("Press enter to continue");
                ShowMenu();
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
                ShowMenu();
                break;
            case "3":
                string searchName = ConsoleInputHelper.ReadString("Enter client name to search");
                var owner = OwnerService.GetOwnerByName(searchName);

                if (owner != null)
                    Console.WriteLine($"Client found: {owner.Name} {owner.LastName}, Email: {owner.Email}, Phone: {owner.Phone}");
                else
                    Console.WriteLine("Client not found.");
                break;
            case "4":
                ShowUpdateOwnerMenu.Show();
                break;
            case "5":
                string idClient = ConsoleInputHelper.ReadString("Enter the client ID");
                OwnerService.DeleteOwner(idClient);
                break;
            case "6":
                string petName = ConsoleInputHelper.ReadString("Enter pet name");
                int petAge = ConsoleInputHelper.ReadInt("Enter pet age");
                string petSpecie = ConsoleInputHelper.ReadString("Enter pet specie");
                string petRace = ConsoleInputHelper.ReadString("Enter the pet race:");
                string ownerId = ConsoleInputHelper.ReadString("Enter the owner Identification:");

                PatientService.CreatePatient(petName, petAge, petSpecie, petRace, ownerId);
                break;
            case "7":
                PatientService.GetAllPatients();
                break;
            case "8":
                ShowUpdatePatientMenu.Show();
                break;
            case "9":
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
            case "10":
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
            case "11":
                string idPatient = ConsoleInputHelper.ReadString("Enter the patient ID to delete:");
                PatientService.DeletePatient(idPatient);
                break;
            case "12":
                string vetName = ConsoleInputHelper.ReadString("Enter veterinary name");
                string vetLastName = ConsoleInputHelper.ReadString("Enter veterinary last name");
                string vetIdentification = ConsoleInputHelper.ReadString("Enter veterinary identification");
                string vetEmail = ConsoleInputHelper.ReadString("Enter veterinary email");
                string vetPhone = ConsoleInputHelper.ReadString("Enter veterinary phone number");
                string vetAge = ConsoleInputHelper.ReadString("Enter veterinary age");
                string vetProfessionalLicense = ConsoleInputHelper.ReadString("Enter veterinary professional license");
                string vetSpecialty = ConsoleInputHelper.ReadString("Enter veterinary specialty");
                string vetYearsOfExperience = ConsoleInputHelper.ReadString("Enter veterinary years of experience");

                VeterinaryService.CreateVeterinary(vetName, vetLastName, vetIdentification, vetEmail, vetPhone, int.Parse(vetAge), vetProfessionalLicense, vetSpecialty, int.Parse(vetYearsOfExperience));
                break;
            case "13":
                VeterinaryService.GetVeterinarians();
                break;
            case "14":
                break; 
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    } 
}