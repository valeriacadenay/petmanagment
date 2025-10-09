using petmanagment.Models;

/*
namespace petmanagment.Services
{
    public class PatientService
    {
        // Método para registrar un nuevo paciente y devolverlo
        public static Patient RegisterPatient(
            List<Patient> patientList, 
            Dictionary<int, Patient> patientDict, 
            List<Owner> owners, 
            ref int patientIdCounter)
        {
            try
            {
                Console.Write("Enter patient's first name: ");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty");
                    return null;
                }

                Console.Write("Enter patient's age: ");
                if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
                {
                    Console.WriteLine("Please enter a valid age");
                    return null;
                }

                Console.Write("Enter patient's specie: ");
                string specie = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(specie))
                {
                    Console.WriteLine("Specie cannot be empty");
                    return null;
                }

                Console.Write("Enter patient's race: ");
                string race = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(race))
                {
                    Console.WriteLine("Race cannot be empty");
                    return null;
                }

                Console.Write("Enter patient's symptoms: ");
                string symptoms = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(symptoms))
                {
                    Console.WriteLine("Symptoms cannot be empty");
                    return null;
                }

                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("       Enter owner's information:");

                Console.Write("Owner's first name: ");
                string ownerName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ownerName))
                {
                    Console.WriteLine("Owner's first name cannot be empty");
                    return null;
                }

                Console.Write("Owner's last name: ");
                string ownerLastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ownerLastName))
                {
                    Console.WriteLine("Owner's last name cannot be empty");
                    return null;
                }

                Console.Write("Owner's age: ");
                if (!int.TryParse(Console.ReadLine(), out int ownerAge) || ownerAge <= 0)
                {
                    Console.WriteLine("Please enter a valid owner age.");
                    return null;
                }

                Console.Write("Owner's email: ");
                string ownerEmail = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ownerEmail))
                {
                    Console.WriteLine("Owner's email cannot be empty");
                    return null;
                }

                Console.Write("Owner's phone: ");
                string ownerPhone = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ownerPhone))
                {
                    Console.WriteLine("Owner's phone cannot be empty");
                    return null;
                }

                // Verificar si el dueño ya existe por email
                Owner existingOwner = owners.FirstOrDefault(o => 
                    o.Email.Equals(ownerEmail, StringComparison.OrdinalIgnoreCase));

                Owner owner;
                if (existingOwner != null)
                {
                    owner = existingOwner;
                }
                else
                {
                    owner = new Owner(ownerName, ownerLastName, ownerAge, ownerEmail, ownerPhone);
                    owners.Add(owner);
                }

                // Asignar ID y crear paciente
                int newPatientId = patientIdCounter++;
                Patient newPatient = new Patient(name, age, specie, race, owner);

                // Agregar a las colecciones
                patientList.Add(newPatient);
                patientDict[newPatientId] = newPatient;

                Console.WriteLine($"Patient registered successfully with ID: {newPatientId}");
                Console.Write("The animal makes a generic sound: ");
                newPatient.EmitSound();

                return newPatient;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        // Métodos ListPatients y SearchPatientByName quedan igual
        public static void ListPatients(List<Patient> patientList)
        {
            if (patientList.Count == 0)
            {
                Console.WriteLine("There are no patients registered.");
                return;
            }

            Console.WriteLine("List of patients:");
            foreach (var patient in patientList)
            {
                Console.WriteLine($"{patient.Name}, Age: {patient.Age}, Specie: {patient.Specie}, Race: {patient.Race}");
            }
        }

        public static void SearchPatientByName(List<Patient> patientList, string name)
        {
            var patient = patientList.FirstOrDefault(p =>
                string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));

            if (patient != null)
            {
                Console.WriteLine($"Patient found: {patient.Name}, Age: {patient.Age}");
            }
            else
            {
                Console.WriteLine("Patient not found");
            }
        }
        
    }
}
*/
