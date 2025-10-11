using petmanagment.Models.Interface;
using petmanagment.Services;

namespace petmanagment.Utils;

public class VeterinaryMenu
{
    public static void VeterinaryShowMenu()
    {
        Console.WriteLine("\n--- MENU VETERINARIES ---");
        Console.WriteLine("1. Register a new veterinary");
        Console.WriteLine("2. List veterinarians");
        Console.WriteLine("3. Search veterinarians");
        Console.WriteLine("4. Update veterinarians");
        Console.WriteLine("5. Delete veterinarians");
        Console.WriteLine("0. Return to main menu");
        Console.WriteLine("Enter an option");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
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
            
            case "2":
                var veterinarians = VeterinaryService.GetVeterinarians();
                if (veterinarians.Count == 0)
                {
                    Console.WriteLine("No clients found.");
                }
                else
                {
                    Console.WriteLine("Clients List:");
                    foreach (var vetinary in veterinarians)
                    {
                        Console.WriteLine($"- Veterinary Name: {vetinary.Name} {vetinary.LastName}, Identification: {vetinary.Identification},  Email: {vetinary.Email}");
                    }
                }
                break;
            case "3":
                string veterinaryName = ConsoleInputHelper.ReadString("Enter veterinary name to search");
                VeterinaryService.GetVeterinaryByName(veterinaryName);
                if (veterinaryName != null)
                {
                    Console.WriteLine($"Patient found: {veterinaryName}");
                }
                else
                {
                    Console.WriteLine("Patient not found.");
                }
                break;
            case "4":
                break;
            case "5":
                string idVeterinary = ConsoleInputHelper.ReadString("Enter the veterinary ID to delete:");
                PatientService.DeletePatient(idVeterinary);
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