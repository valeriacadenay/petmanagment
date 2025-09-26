
using petmanagment.Models;
using petmanagment.Services;
using petmanagment.Models.Interface;


Dictionary<int, Patient> patientDict = new Dictionary<int, Patient>();
List<Owner> owners = new List<Owner>();
int patientIdCounter = 1; // empieza desde 1

bool flag = true;

ConsoleInterface.ShowTitle("Pet Health Clinic");

while (flag)
{
    Console.WriteLine("");
    Console.WriteLine("------------ MAIN MENU ------------");
    Console.WriteLine("1. Register patient");
    Console.WriteLine("2. List patients");
    Console.WriteLine("3. Search for patient");
    Console.WriteLine("4. Search a patient by age or species");
    Console.WriteLine("5. Exit");
    Console.Write("Select an option: ");
    
    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            PatientService.RegisterPatient(patientDict,owners, ref patientIdCounter);
            break;
        case "2":
            PatientService.ListPatients(patientDict);
            break;
        case "3":
            Console.Write("Enter the ID of the patient: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                PatientService.SearchPatientById(patientDict, id);
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
            break;
        case "4":
            Console.Write("Enter the age or the specie of the patient: ");
            string input = Console.ReadLine();
            if (input == "Age")
            {
                Console.WriteLine("Enter the age of the patient");
                int age;
                //SearchPatientByAgeOrSpecies(patientDict, age, null);
            }
            else if(input == "specie")
            {
                
                //SearchPatientByAgeOrSpecies(patientDict, null, specie);
            }
            break;
        case "5":
            flag = false;
            ConsoleInterface.ShowFoot("Thanks for using the system");
            break;
        default:
            Console.WriteLine("Please input a valid option, try again");
            break;
    }
    
}