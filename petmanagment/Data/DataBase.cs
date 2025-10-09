using petmanagment.Models;
using petmanagment.Repositories;

namespace petmanagment.Data;


public class DataBase
{
    public static List<Patient> patients = [];
    public static List<Owner> owners = [];
    public static List<Veterinary> veterinarys = [];
    public static List<ServiceVeterinary> services = [];
}