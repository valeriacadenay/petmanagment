using petmanagment.Models;

namespace petmanagment.Data;


public static class DataBase
{
    public static List<Owner> Owners = [];
    public static List<Patient> Patients = new List<Patient>();
    public static List<Veterinary> Veterinarys = new List<Veterinary>();
    public static List<ServiceVeterinary> Services = new List<ServiceVeterinary>();
    public static List<string> AvailableServices = new List<string>
    {
        "Vacunación",
        "Consulta General",
        "Cirugía",
        "Limpieza Dental",
        "Atención de Emergencia"
    };



    static DataBase()
    {
        var owner1 = new Owner("John", "Doe", "123456789", "John@email.com", "12345", 45);
        var owner2 = new Owner("John", "Doe", "123456789", "John@email.com", "12345",20);
        
        Owners.Add(owner1);
        Owners.Add(owner2);

        var pet1 = new Patient("Bruno", 3, "Dog", "French Bulldog", owner2.Identification);
        Patients.Add(pet1);

        var vet1 = new Veterinary("Susana", "Lopez", "12343232", "susana@email.com",
            "30333369", 29, "2327634823", "Odontologa", 3);
        Veterinarys.Add(vet1);

    }
}