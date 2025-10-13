using petmanagment.Data;
using petmanagment.Interfaces;
using petmanagment.Models;

namespace petmanagment.Repositories;

public class OwnerRepository : IRegistrable<Owner>, IReadable<Owner>, IUpdatePerson, IRemovable 
{
    public void Register(Owner owner)
    {
        DataBase.Owners.Add(owner);
    }
    
    public List<Owner> GetAll(){
        return DataBase.Owners;
    }

    public Owner? GetById(string id)
    {
        return DataBase.Owners.Find((owner => owner.Identification.ToString() == id));
    }
    

    public Owner? GetByName(string name)
    {
        return DataBase.Owners.Find((owner => owner.Name == name));
    }
    
    // Filtra todas las mascotas cuyo campo OwnerIdentification coincida
    public List<Patient> GetPetsByOwnerIdentification(string ownerIdentification)
    {
        var pets = DataBase.Patients
            .Where(p => p.OwnerIdentification == ownerIdentification)
            .ToList();

        return pets;
    }


    public void UpdateOwnerName(string newName)
    {
        DataBase.Owners = DataBase.Owners.Select((owner) =>
        {
            if (owner.Name == newName)
            {
                owner.Name = newName;
                return owner;
            }

            return owner;
        }).ToList();
    }
    public void UpdateOwnerLastName(string LastName)
    {
        DataBase.Owners = DataBase.Owners.Select((owner) =>
        {
            if (owner.LastName == LastName)
            {
                owner.LastName = LastName;
                return owner;
            }

            return owner;
        }).ToList();
    }

    public void updateOwnerEmail(string email)
    {
        DataBase.Owners = DataBase.Owners.Select((owner) =>
        {
            if (owner.Email == email)
            {
                owner.Email = email;
                return owner;
            }

            return owner;
        }).ToList();
    }

    public void updateOwnerPhone(string phone)
    {
        DataBase.Owners = DataBase.Owners.Select((owner) =>
        {
            if (owner.Phone == phone)
            {
                owner.Phone = phone;
                return owner;
            }

            return owner;
        }).ToList();
    }

    public void updateOwnerIdentification(string identification)
    {
        DataBase.Owners = DataBase.Owners.Select((owner) =>
        {
            if (owner.Identification == identification)
            {
                owner.Identification = identification;
                return owner;
            }
            return owner;
        }).ToList();
    }

    public void updateOwnerAge(int age)
    {
        DataBase.Owners.Select((owner =>
        {
            if (owner.Age == age)
            {
                owner.Age = age;
                return owner;
            }

            return owner;
        }));
    }

    public void Remove(string id)
    {
        DataBase.Owners.Where((owner => owner.Id.ToString() != id));
    }

    public void AddPet(Patient pet)
    {
        DataBase.Owners = DataBase.Owners.Select((owner) =>
        {
            if (owner.Identification == pet.OwnerIdentification)
            {
                owner.addPet(pet);
                return owner;
            }

            return owner;
        }).ToList();
    }

    public void removePet(Patient pet)
    {
        DataBase.Owners = DataBase.Owners.Select((owner) =>
        {
            if (owner.Pets.Contains(pet))
            {
                owner.removePet(pet.Id.ToString());
                return owner;
            }

            return owner;
        }).ToList();
    }
}