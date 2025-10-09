using petmanagment.Repositories;
using petmanagment.Models;

namespace petmanagment.Services;

public class OwnerService
{
    private static OwnerRepository _ownerRepository = new OwnerRepository();
    
    public static void CreateOwner(string name,
                                   string lastName,
                                   string identification,
                                   string email,
                                   string phone,
                                   int Age)
    {
        if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName) || 
           string.IsNullOrEmpty(identification) || string.IsNullOrEmpty(email) || 
           string.IsNullOrEmpty(phone) || Age <= 0 || Age >100 )
        {
            Console.WriteLine("Invalid input. Please provide valid owner details.");
            return;
        }

        try
        {
            Owner newOwner = new Owner(name, lastName, identification, Age, email, phone);
            _ownerRepository.Register(newOwner);
            Console.WriteLine("Owner created successfully.");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error creating owner: {ex.Message}");
        }
    }

    public static List<Owner> GetOwners()
    {
        try
        {
            return _ownerRepository.GetAll();
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error retrieving owners: {ex.Message}");
            return [];
        }   
    }
    
    public static Owner? GetOwnerById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
           Console.WriteLine("Invalid Id");
           return null;
        }
        try
        {
            return _ownerRepository.GetById(id);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error retrieving owner: {ex.Message}");
            return null;
        }
    }

    public static Owner? GetOwnerByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Invalid Name");
            return null;
        }

        try
        {
            return _ownerRepository.GetByName(name);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error retrieving owner: {ex.Message}");
            return null;
        }
    }

    public static void UpdateOwner(string id,
                                   string newName, 
                                   string newLastName,
                                   string Identification,
                                   string newEmail,
                                   string newPhone,
                                   int newAge)
    {
        if(string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newLastName) || string.IsNullOrEmpty(Identification) || 
           string.IsNullOrEmpty(newEmail) || string.IsNullOrEmpty(newPhone) || 
           newAge <= 0 || newAge > 100)
        {
            Console.WriteLine("Invalid input. Please provide valid owner details.");
            return;
        }

        try
        {
            Owner updatedOwner = new Owner(newName, newLastName, Identification, newAge, newEmail, newPhone);
            _ownerRepository.Edit(Identification, updatedOwner);
            Console.WriteLine("Owner updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating owner: {ex.Message}");
        }
    }

    public static void DeleteOwner(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }
        try
        {
            _ownerRepository.Remove(id);
            Console.WriteLine("Owner deleted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting owner: {ex.Message}");
        }
    }

    public static void addPetToOwner(Patient pet)
    {
        try
        {
            _ownerRepository.AddPet(pet);
            Console.WriteLine("Pet added to owner successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding pet to owner: {ex.Message}");
        }
    }
    public static void removePetFromOwner(Patient pet)
    {
        try
        {
            _ownerRepository.removePet(pet);
            Console.WriteLine("Pet removed from owner successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error removing pet from owner: {ex.Message}");
        }
    }
}