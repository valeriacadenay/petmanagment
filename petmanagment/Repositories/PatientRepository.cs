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
        DataBase.Patients.Add(patient);
    }
    
    public List<Patient> GetAll(){
        return DataBase.Patients;
    }

    public Patient? GetById(string identification)
    {
        return DataBase.Patients.Find((patient => patient.Id.ToString() == identification));
    }

    public Patient? GetByName(string name)
    {
        return DataBase.Patients.Find((patient => patient.Name == name));
    }
    
    public void UpdatePatientName(string newName)
    {
        DataBase.Patients = DataBase.Patients.Select((patient) =>
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
        DataBase.Patients = DataBase.Patients.Select((patient) =>
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
        DataBase.Patients = DataBase.Patients.Select((patient) =>
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
        DataBase.Patients = DataBase.Patients.Select((patient =>
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
        DataBase.Patients.Where((patient => patient.Id.ToString() != id));
    }
}