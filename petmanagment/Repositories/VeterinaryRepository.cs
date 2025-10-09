using petmanagment.Models;
using petmanagment.Data;
using petmanagment.Interfaces;


namespace petmanagment.Repositories;

public class VeterinaryRepository :IRegistrable<Veterinary>, IReadable<Veterinary>, IEditable<Veterinary>, IRemovable 
{
    public VeterinaryRepository()
    {
    }
    public void Register(Veterinary veterinary)
    {
        DataBase.veterinarys.Add(veterinary);
    }
    
    public List<Veterinary> GetAll(){
        return DataBase.veterinarys;
    }

    public Veterinary? GetById(string id)
    {
        return DataBase.veterinarys.Find((veterinary => veterinary.Id.ToString() == id));
    }

    public Veterinary? GetByName(string name)
    {
        return DataBase.veterinarys.Find((veterinary => veterinary.Name == name));
    }
    
    public void Edit(string identification, Veterinary veterinary)
    {
        DataBase.veterinarys = DataBase.veterinarys.Select((vet => vet.Identification == identification ? veterinary: vet)).ToList();
    }
    
    public void Remove(string id)
    {
        DataBase.veterinarys = DataBase.veterinarys.Where((vet => vet.Id.ToString() != id)).ToList();
    }
}