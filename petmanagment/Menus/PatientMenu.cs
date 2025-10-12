using petmanagment.Services;
using petmanagment.Utils;

namespace petmanagment.Menus
{
    public static class PatientMenu
    {
        public static void Show()
        {
            bool back = false;

            while (!back)
            {
                ConsoleUI.Title("🐶 PATIENT MENU");
                Console.WriteLine("1. Register new pet");
                Console.WriteLine("2. Show all pets");
                Console.WriteLine("3. Search Pets by Name");
                Console.WriteLine("4. Update Pet Information");
                Console.WriteLine("5. Delete Pet");
                Console.WriteLine("9. Back to Main Menu");
                ConsoleUI.Separator();

                string option = ConsoleUI.ReadOption();

                switch (option)
                {
                    case "1":
                        string petName = ConsoleInputHelper.ReadString("Enter pet name");
                        int petAge = ConsoleInputHelper.ReadInt("Enter pet age");
                        string petSpecie = ConsoleInputHelper.ReadString("Enter pet specie");
                        string petRace = ConsoleInputHelper.ReadString("Enter the pet race:");
                        string ownerId = ConsoleInputHelper.ReadString("Enter the owner Identification:");

                        PatientService.CreatePatient(petName, petAge, petSpecie, petRace, ownerId);
                        Console.WriteLine("→ Registering new pet...");
                        break;
                    case "2":
                        var patients = PatientService.GetAllPatients();
                        if (patients.Count == 0)
                        {
                            Console.WriteLine("No clients found.");
                        }
                        else
                        {
                            Console.WriteLine("Clients List:");
                            foreach (var patient in patients)
                            {
                                Console.WriteLine($"- {patient.Name} , Specie: {patient.Specie}, Race:{patient.Race},  Age: {patient.Age}, Owner Identification : {patient.OwnerIdentification}");
                            }
                        }
                        break;
                    case "3":
                        string patientName = ConsoleInputHelper.ReadString("Enter patient name to search");
                        PatientService.GetPatientByName(patientName);
                        if (patientName != null)
                        {
                            Console.WriteLine($"Patient found: {patientName}");
                        }
                        else
                        {
                            Console.WriteLine("Patient not found.");
                        }
                        break;
                    case "4":
                        UpdatePet.Show();
                        break;
                    case "5":
                        string idPatient = ConsoleInputHelper.ReadString("Enter the patient ID to delete:");
                        PatientService.DeletePatient(idPatient);
                        break;
                    case "9":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }

                if (!back)
                    ConsoleUI.Pause();
            }
        }
    }
}