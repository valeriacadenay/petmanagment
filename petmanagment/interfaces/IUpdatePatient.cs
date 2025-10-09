namespace petmanagment.Interfaces;

public interface IUpdatePatient
{
    public void UpdatePatientName(string newName);
    public void UpdatePatientAge(int newAge);
    public void UpdatePatientSpecie(string newSpecie);
    public void UpdatePatientRace(string newRace);
    
}