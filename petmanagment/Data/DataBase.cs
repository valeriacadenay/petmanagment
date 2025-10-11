using petmanagment.Models;

namespace petmanagment.Data;


public static class DataBase
{
    public static List<Owner> Owners = [];
    public static List<Patient> Patients = new List<Patient>();
    public static List<Veterinary> Veterinarys = new List<Veterinary>();
    public static List<ServiceVeterinary> Services = new List<ServiceVeterinary>();


    static DataBase()
    {
        var owner1 = new Owner("John", "Doe", "123456789", "John@email.com", "12345", 45);
        var owner2 = new Owner("John", "Doe", "123456789", "John@email.com", "12345",20);
        
        Owners.Add(owner1);
        Owners.Add(owner2);
    }
}