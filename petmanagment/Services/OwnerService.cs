using petmanagment.Repositories;
using petmanagment.Models;

namespace petmanagment.Services;

public class OwnerService
{
    private static OwnerRepository _ownerRepository = new OwnerRepository();
    private static PatientRepository _petRepository = new PatientRepository();
    
    public static void CreateOwner(string name,
                                   string lastName,
                                   string identification,
                                   string email,
                                   string phone,
                                   int age)
    {
        if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName) || 
           string.IsNullOrEmpty(identification) || string.IsNullOrEmpty(email) || 
           string.IsNullOrEmpty(phone) || age <= 0 || age >100 )
        {
            Console.WriteLine("Invalid input. Please provide valid owner details.");
            return;
        }

        try
        {
            Owner newOwner = new Owner(name, lastName, identification, email, phone,age);
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
    
    //
    public static List<Patient> GetPetsByOwnerIdentification(string ownerIdentification)
    {
        if (string.IsNullOrEmpty(ownerIdentification))
        {
            Console.WriteLine("Invalid owner identification.");
            return [];
        }

        try
        {
            var pets = _ownerRepository.GetPetsByOwnerIdentification(ownerIdentification);

            if (pets.Count == 0)
            {
                Console.WriteLine("This owner has no registered pets.");
            }

            return pets;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error retrieving pets: {ex.Message}");
            return [];
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
    
    public static void UpdateOwnerName(string id, string newName)
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newName))
        {
            Console.WriteLine($"Invalid Id or Name");
        }

        try
        {
            Owner? updateOwner = _ownerRepository.GetById(id);
            if (updateOwner == null)
            {
                Console.WriteLine("Owner not found.");
            }

            updateOwner.Name = newName;
            _ownerRepository.UpdateOwnerName(newName);
            Console.WriteLine("Owner name updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Updating the owner: {ex.Message}");
        }
    }

    public static void UpdateOwnerLastName(string id, string newLastName)
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newLastName))
        {
            Console.WriteLine($"Invalid Id or Last Name");
        }

        try
        {
            Owner? updateOwner = _ownerRepository.GetById(id);
            if (updateOwner == null)
            {
                Console.WriteLine("Owner not found.");
            }

            updateOwner.Name = newLastName;
            _ownerRepository.UpdateOwnerName(newLastName);
            Console.WriteLine("Owner Last name updated successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public static void UpdateOwnerEmail(string id, string newEmail)
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newEmail))
        {
            Console.WriteLine($"Invalid Id or Email");
        }

        try
        {
            Owner? updateOwner = _ownerRepository.GetById(id);
            if (updateOwner == null)
            {
                Console.WriteLine("Owner not found.");
            }

            updateOwner.Email = newEmail;
            _ownerRepository.updateOwnerEmail(newEmail);
            Console.WriteLine("Owner Email updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Updating the owner: {ex.Message}");
        }
    }
    public static void UpdateOwnerPhone(string id, string newPhone)
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newPhone))
        {
            Console.WriteLine($"Invalid Id or Phone");
        }

        try
        {
            Owner? updateOwner = _ownerRepository.GetById(id);
            if (updateOwner == null)
            {
                Console.WriteLine("Owner not found.");
            }

            updateOwner.Phone = newPhone;
            _ownerRepository.updateOwnerPhone(newPhone);
            Console.WriteLine("Owner Phone updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Updating the owner: {ex.Message}");
        }
    }
    
    public static void DeleteOwner(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
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