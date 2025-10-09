namespace petmanagment.Repositories;
using petmanagment.Data;
using petmanagment.Interfaces;
using petmanagment.Models;

public class PatientRepository : IRegistrable<Patient>, IReadable<Patient>, IEditable<Patient>, IRemovable 
{
    public PatientRepository()
    {
    }
    public void Register(Patient patient)
    {
        DataBase.patients.Add(patient);
    }
    
    public List<Patient> GetAll(){
        return DataBase.patients;
    }

    public Patient? GetById(string identification)
    {
        return DataBase.patients.Find((patient => patient.Id.ToString() == identification));
    }

    public Patient? GetByName(string name)
    {
        return DataBase.patients.Find((patient => patient.Name == name));
    }
    
    public void Edit(string id, Patient patient)
    {
        DataBase.patients = DataBase.patients.Select((patient1 => patient1.Id.ToString() == id ? patient : patient1)).ToList();
    }
    

    public void Remove(string id)
    {
        DataBase.patients = DataBase.patients.Where((patient => patient.Id.ToString() != id)).ToList();
    }
}