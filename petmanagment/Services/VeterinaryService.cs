using petmanagment.Models;

namespace petmanagment.Services;
using petmanagment.Repositories;

public class VeterinaryService
{
    private static VeterinaryRepository _veterinaryService = new VeterinaryRepository();

    public static void CreateVeterinary(string name,
        string lastName,
        string identification,
        string email,
        string phone,
        int age,
        string professionalLicense,
        string specialty,
        int yearsOfExperience
    )
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName) ||
            string.IsNullOrEmpty(identification) || string.IsNullOrEmpty(email) ||
            string.IsNullOrEmpty(phone) || age <= 0 || age > 100 || string.IsNullOrEmpty(professionalLicense)|| 
            string.IsNullOrEmpty(specialty) || yearsOfExperience <= 0)
        {
            Console.WriteLine("Invalid input. Please provide valid veterinary details.");
            return;
        } 
        try
        {
            Veterinary newVeterinary = new Veterinary(name, lastName, identification, email, phone, age,
                professionalLicense, specialty, yearsOfExperience);
            _veterinaryService.Register(newVeterinary);
            Console.WriteLine("Veterinary created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating veterinary: {ex.Message}");
        }
    }

    public static List<Veterinary> GetVeterinarians()
    {
        try
        {
            return _veterinaryService.GetAll();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving veterinarians: {ex.Message}");
            return [];
        }
    }

    public static Veterinary? GetVeterinaryById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return null;
        }

        try
        {
            return _veterinaryService.GetById(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving veterinary: {ex.Message}");
            return null;
        }
    }

    public static Veterinary? GetVeterinaryByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Invalid Name");
            return null;
        }

        try
        {
            return _veterinaryService.GetByName(name);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving veterinary: {ex.Message}");
            return null;
        }
    }

    public static void UpdateVeterinary(string identification, Veterinary veterinary)
    {
        if (string.IsNullOrEmpty(identification) || veterinary == null)
        {
            Console.WriteLine("Invalid input. Please provide valid veterinary details.");
            return;
        }

        try
        {
            _veterinaryService.Edit(identification, veterinary);
            Console.WriteLine("Veterinary updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating veterinary: {ex.Message}");
        }
    }

    public static void DeleteVeterinary(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        try
        {
            _veterinaryService.Remove(id);
            Console.WriteLine("Veterinary deleted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error deleting veterinary: {ex.Message}");
        }
    }

}