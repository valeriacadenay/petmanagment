using petmanagment.Services;

namespace petmanagment.Models.Interface;

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
        ConsoleInterface.ShowSeparator();

        switch (option)
        {
            case "0":
                Console.WriteLine("Exiting the program. Goodbye!");
                Environment.Exit(0);
                break;
            case "1":
                OwnerService.CreateOwner();
                break;
            case "2":
                OwnerService.GetOwners();
                break;
            case "3":
                OwnerService.GetOwnerByName();
                break;
            case "4":
                OwnerService.
                break;
            case "5":
                ClientService.DeleteClient();
                break;
            case "6":
                PatientService.RegisterPatient();
                break;
            case "7":
                PatientService.ListPatients();
                break;
            case "8":
                PatientService.UpdatePatientInformation();
                break;
            case "10":
                PatientService.SearchPatientById();
                break;
            case "11":
                PatientService.DeletePatient();
                break;
            case "12":
                VeterinaryService.RegisterVeterinary();
                break;
            case "13":
                VeterinaryService.ListVeterinaries();
                break;
            case "14":
                VeterinaryService.SearchVeterinaryById();
                break;
            case "15":
                VeterinaryService.UpdateVeterinaryInformation();
                break;
            case "16":
                VeterinaryService.DeleteVeterinary();
                break;
            case "17":
                ServiceVeterinaryService.RequestVeterinaryService();
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
    
}