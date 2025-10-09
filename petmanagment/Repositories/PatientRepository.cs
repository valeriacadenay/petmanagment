namespace petmanagment.Repositories;
using petmanagment.Data;
using petmanagment.Interfaces;
using petmanagment.Models;

public class PatientRepository : IRegistrable<Patient>, IReadable<Patient>, IUpdatePatient, IRemovable 
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
    
    public void UpdatePatientName(string newName)
    {
        DataBase.patients = DataBase.patients.Select((patient) =>
        {
            if (patient.Name == newName)
            {
                patient.Name = newName;
                return patient;
            }

            return patient;
        }).ToList();
    }

    public void UpdatePatientAge(int newAge)
    {
        DataBase.patients = DataBase.patients.Select((patient) =>
        {
            if (patient.Age == newAge)
            {
                patient.Age = newAge;
                return patient;
            }

            return patient;
        }).ToList();
    }
    public void UpdatePatientSpecie(string newSpecie)
    {
        DataBase.patients = DataBase.patients.Select((patient) =>
        {
            if (patient.Specie == newSpecie)
            {
                patient.Specie = newSpecie;
                return patient;
            }

            return patient;
        }).ToList();
    }

    public void UpdatePatientRace(string newRace)
    {
        DataBase.patients = DataBase.patients.Select((patient =>
        {
            if (patient.Race == newRace)
            {
                patient.Race = newRace;
                return patient;
            }

            return patient;
        })).ToList();
    }


    public void Remove(string id)
    {
        DataBase.patients = DataBase.patients.Where((patient => patient.Id.ToString() != id)).ToList();
    }
}