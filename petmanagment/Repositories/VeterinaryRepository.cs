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
        DataBase.Veterinarys.Add(veterinary);
    }
    
    public List<Veterinary> GetAll(){
        return DataBase.Veterinarys;
    }

    public Veterinary? GetById(string id)
    {
        return DataBase.Veterinarys.Find((veterinary => veterinary.Id.ToString() == id));
    }

    public Veterinary? GetByName(string name)
    {
        return DataBase.Veterinarys.Find((veterinary => veterinary.Name == name));
    }
    
    public void Edit(string identification, Veterinary veterinary)
    {
        DataBase.Veterinarys = DataBase.Veterinarys.Select((vet => vet.Identification == identification ? veterinary: vet)).ToList();
    }
    
    public void Remove(string id)
    {
        DataBase.Veterinarys = DataBase.Veterinarys.Where((vet => vet.Id.ToString() != id)).ToList();
    }
}