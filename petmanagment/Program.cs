
using petmanagment.Models;
using petmanagment.Services;
using petmanagment.Models.Interface;


List<Patient> pacients = new List<Patient>();
bool flag = true;

ConsoleInterface.ShowTitle("Pet Health Clinic");

while (flag)
{
    Console.WriteLine("");
    Console.WriteLine("------------ MAIN MENU ------------");
    Console.WriteLine("1. Register patient");
    Console.WriteLine("2. List patients");
    Console.WriteLine("3. Search for patient");
    Console.WriteLine("4. Exit");
    Console.Write("Select an option: ");
    
    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            PatientService.RegisterPatient(pacients);
            break;
        case "2":
            PatientService.ListPatients(pacients);
            break;
        case "3":
            Console.Write("Enter the name of the pacient ");
            string name = Console.ReadLine();
            PatientService.SearchPatientByName(pacients, name);
            break;
        case "4":
            flag = false;
            ConsoleInterface.ShowFoot("Thanks for using the system");
            break;
        default:
            Console.WriteLine("Please input a valid option, try again");
            break;
    }
    
}