using petmanagment.Interfaces;
using petmanagment.Models;


namespace petmanagment.Services
{
    public class PatientService : IRegistrable
    {
        private List<Patient> _patientList;
        private Dictionary<int, Patient> _patientDict;
        private List<Owner> _owners;
        private int _patientIdCounter;

        public PatientService(List<Patient> patientList, Dictionary<int, Patient> patientDict, List<Owner> owners,
            int startingPatientId)
        {
            _patientList = patientList;
            _patientDict = patientDict;
            _owners = owners;
            _patientIdCounter = startingPatientId;
        }

        public void Register()
        {
            try
            {
                Console.Write("Enter patient's first name: ");
                string name = Console.ReadLine();

                Console.Write("Enter patient's age: ");
                if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
                {
                    Console.WriteLine("Please enter a valid age.");
                    return;
                }

                Console.Write("Enter patient's specie: ");
                string specie = Console.ReadLine()?.ToLower() ?? "";

                Console.Write("Enter patient's race: ");
                string race = Console.ReadLine();

                // Owner data
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
                    return;
                }

                Console.Write("Owner's email: ");
                string ownerEmail = Console.ReadLine();

                Console.Write("Owner's phone: ");
                string ownerPhone = Console.ReadLine();

                // Verify if the owner already exits in the database
                Owner existingOwner =
                    _owners.FirstOrDefault(o => o.Email.Equals(ownerEmail, StringComparison.OrdinalIgnoreCase));
                Owner owner;

                if (existingOwner != null)
                {
                    owner = existingOwner;
                    Console.WriteLine("Owner already exists, linking existing owner to patient.");
                }
                else
                {
                    owner = new Owner(ownerName, ownerLastName, ownerAge, ownerEmail, ownerPhone);
                    _owners.Add(owner);
                }

                // Create and asing patiend Id
                int newPatientId = _patientIdCounter++;
                Patient newPatient = new Patient(name, age, specie, race, owner);
                _patientList.Add(newPatient);
                _patientDict[newPatientId] = newPatient;

                Console.WriteLine($"Patient registered successfully with ID: {newPatientId}");
                Console.Write("The animal makes a generic sound: ");
                newPatient.EmitSound();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ListPatients()
        {
            if (_patientDict.Count == 0)
            {
                Console.WriteLine("No patients registered.");
                return;
            }

            Console.WriteLine("List of patients:");
            foreach (var kvp in _patientDict)
            {
                Console.WriteLine(
                    $"ID: {kvp.Key}, Name: {kvp.Value.Name}, Age: {kvp.Value.Age}, Specie: {kvp.Value.Specie}");
            }
        }

        public void SearchPatientById(int id)
        {
            if (_patientDict.TryGetValue(id, out Patient patient))
            {
                Console.WriteLine(
                    $"Patient found: {patient.Name}, Age: {patient.Age}, Specie: {patient.Specie}, Owner: {patient.Owner.Name} {patient.Owner.LastName}");
            }
            else
            {
                Console.WriteLine("Patient not found with the given ID.");
            }
        }

        public void SearchPatientByAgeOrSpecies(int? age, string specie)
        {
            var result = _patientDict.Where(p =>
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
                    Console.WriteLine(
                        $"ID: {entry.Key}, Name: {entry.Value.Name}, Age: {entry.Value.Age}, Specie: {entry.Value.Specie}");
                }
            }
        }
    }
}

