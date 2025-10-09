using petmanagment.Data;
using petmanagment.Interfaces;
using petmanagment.Models;

namespace petmanagment.Repositories;

public class OwnerRepository : IRegistrable<Owner>, IReadable<Owner>, IUpdatePerson, IRemovable 
{
    public OwnerRepository()
    {
    }

    public void Register(Owner owner)
    {
        DataBase.owners.Add(owner);
    }
    
    public List<Owner> GetAll(){
        return DataBase.owners;
    }

    public Owner? GetById(string id)
    {
        return DataBase.owners.Find((owner => owner.Identification.ToString() == id));
    }

    public Owner? GetByName(string name)
    {
        return DataBase.owners.Find((owner => owner.Name == name));
    }

    public void UpdateOwnerName(string newName)
    {
        DataBase.owners = DataBase.owners.Select((owner) =>
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
        DataBase.owners = DataBase.owners.Select((owner) =>
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
        DataBase.owners = DataBase.owners.Select((owner) =>
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
        DataBase.owners = DataBase.owners.Select((owner) =>
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
        DataBase.owners = DataBase.owners.Select((owner) =>
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
        DataBase.owners = DataBase.owners.Select((owner =>
        {
            if (owner.Age == age)
            {
                owner.Age = age;
                return owner;
            }
            return owner;
        })).ToList();
    }

    public void Remove(string id)
    {
        DataBase.owners = DataBase.owners.Where((owner => owner.Id.ToString() != id)).ToList();
    }

    public void AddPet(Patient pet)
    {
        DataBase.owners = DataBase.owners.Select((owner) =>
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
        DataBase.owners = DataBase.owners.Select((owner) =>
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