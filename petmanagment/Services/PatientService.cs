using petmanagment.Models;


namespace petmanagment.Services
{
    public class PatientService
    {
       public static Patient RegisterPatient(List<Patient> patientList, Dictionary<int, Patient> patientDict, List<Owner> owners, ref int patientIdCounter)
        {
            try
            {
                // Datos del paciente
                Console.Write("Enter patient's first name: ");
                string name = Console.ReadLine();

                Console.Write("Enter patient's age: ");
                if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
                {
                    Console.WriteLine("Please enter a valid age.");
                    return null;
                }

                Console.Write("Enter patient's specie: ");
                string specie = Console.ReadLine()?.ToLower() ?? "";

                Console.Write("Enter patient's race: ");
                string race = Console.ReadLine();

                Console.Write("Enter patient's symptoms: ");
                string symptoms = Console.ReadLine();

                // Datos del dueño
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("       Enter owner's information:");

                Console.Write("Owner's first name: ");
                string ownerName = Console.ReadLine();

                Console.Write("Owner's last name: ");
                string ownerLastName = Console.ReadLine();

                Console.Write("Owner's age: ");
                if (!int.TryParse(Console.ReadLine(), out int ownerAge) || ownerAge <= 0)
                {
                    Console.WriteLine("Please enter a valid owner age.");
                    return null;
                }

                Console.Write("Owner's email: ");
                string ownerEmail = Console.ReadLine();

                Console.Write("Owner's phone: ");
                string ownerPhone = Console.ReadLine();

                // Verificar si el dueño ya existe por email
                Owner existingOwner = owners.FirstOrDefault(o => o.Email.Equals(ownerEmail, StringComparison.OrdinalIgnoreCase));
                Owner owner;

                if (existingOwner != null)
                {
                    owner = existingOwner;
                    Console.WriteLine("Owner already exists, linking existing owner to patient.");
                }
                else
                {
                    owner = new Owner(ownerName, ownerLastName, ownerAge, ownerEmail, ownerPhone);
                    owners.Add(owner);
                }

                // Asignar ID y crear paciente
                int newPatientId = patientIdCounter;
                patientIdCounter++;

                Patient newPatient = new Patient(name, age, specie, race, symptoms, owner);
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

        public static void ListPatients(Dictionary<int, Patient> patientDict)
        {
            if (patientDict.Count == 0)
            {
                Console.WriteLine("No patients registered.");
                return;
            }

            Console.WriteLine("List of patients:");
            foreach (var kvp in patientDict)
            {
                Console.WriteLine($"ID: {kvp.Key}, Name: {kvp.Value.Name}, Age: {kvp.Value.Age}, Specie: {kvp.Value.Specie}");
            }
        }

        public static void SearchPatientById(Dictionary<int, Patient> patientDict, int id)
        {
            if (patientDict.TryGetValue(id, out Patient patient))
            {
                Console.WriteLine($"Patient found: {patient.Name}, Age: {patient.Age}, Specie: {patient.Specie}, Owner: {patient.Owner.Name} {patient.Owner.LastName}");
            }
            else
            {
                Console.WriteLine("Patient not found with the given ID.");
            }
        }

        public static void SearchPatientByAgeOrSpecies(Dictionary<int, Patient> patientDict, int? age, string specie)
        {
            var result = patientDict.Where(p =>
                (age != null && p.Value.Age == age) ||
                (!string.IsNullOrEmpty(specie) && p.Value.Specie.Equals(specie, StringComparison.OrdinalIgnoreCase))
            );

            if (!result.Any())
            {
                Console.WriteLine("No matching patients found.");
            }
            else
            {
                foreach (var entry in result)
                {
                    Console.WriteLine($"ID: {entry.Key}, Name: {entry.Value.Name}, Age: {entry.Value.Age}, Specie: {entry.Value.Specie}");
                }
            }
        }
    }
}
