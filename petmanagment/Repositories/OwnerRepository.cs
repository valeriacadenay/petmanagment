using petmanagment.Data;
using petmanagment.Interfaces;
using petmanagment.Models;

namespace petmanagment.Repositories;

public class OwnerRepository : IRegistrable<Owner>, IReadable<Owner>, IEditable<Owner>, IRemovable 
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
    
    public void Edit(string identification, Owner Owner)
    {
        DataBase.owners = DataBase.owners.Select((own => own.Identification == identification ? Owner : own)).ToList();
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