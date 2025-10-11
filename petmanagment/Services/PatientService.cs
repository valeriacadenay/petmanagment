using petmanagment.Models;
using petmanagment.Repositories;


namespace petmanagment.Services
{
    public class PatientService
    {
        private static PatientRepository _patientRepository = new PatientRepository();

        public static void CreatePatient(string name,
            int age,
            string specie,
            string breed,
            string ownerId)
        {
            if (string.IsNullOrEmpty(name) || age <= 0 || age > 100 ||
                string.IsNullOrEmpty(specie) || string.IsNullOrEmpty(breed) ||
                string.IsNullOrEmpty(ownerId))
            {
                Console.WriteLine("Invalid input. Please provide valid patient details.");
                return;
            }

            try
            {
                Patient newPatient = new Patient(name, age, specie, breed, ownerId);
                _patientRepository.Register(newPatient);
                Console.WriteLine("Patient created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating patient: {ex.Message}");
            }
        }

        public static List<Patient> GetAllPatients()
        {
            try
            {
                return _patientRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving patients: {ex.Message}");
                return [];
            }
        }

        public static Patient? GetPatientById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                Console.WriteLine("Invalid Id");
                return null;
            }

            try
            {
                return _patientRepository.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving patient by Id: {ex.Message}");
                return null;
            }
        }

        public static Patient? GetPatientByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Invalid Name");
                return null;
            }

            try
            {
                return _patientRepository.GetByName(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving patient by Name: {ex.Message}");
                return null;
            }
        }

        public static void UpdatePatientName(string id, string newName)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newName))
            {
                Console.WriteLine("Invalid Id or Name");
                return;
            }

            try
            {
                var patient = _patientRepository.GetById(id);
                if (patient == null)
                {
                    Console.WriteLine("Patient not found.");
                    return;
                }

                patient.Name = newName;
                _patientRepository.UpdatePatientName(newName);
                Console.WriteLine("Patient name updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating patient name: {ex.Message}");
            }
        }

        public static void UpdatePatientAge(string id, int newAge)
        {
            if (string.IsNullOrEmpty(id) || newAge <= 0 || newAge > 100)
            {
                Console.WriteLine("Invalid Id or Age");
                return;
            }

            try
            {
                var patient = _patientRepository.GetById(id);
                if (patient == null)
                {
                    Console.WriteLine("Patient not found.");
                    return;
                }

                patient.Age = newAge;
                _patientRepository.UpdatePatientAge(newAge);
                Console.WriteLine("Patient age updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating patient age: {ex.Message}");
            }
        }

        public static void UpdatePatientSpecie(string id, string newSpecie)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newSpecie))
            {
                Console.WriteLine("Invalid Id or Specie");
                return;
            }

            try
            {
                var patient = _patientRepository.GetById(id);
                if (patient == null)
                {
                    Console.WriteLine("Patient not found.");
                    return;
                }

                patient.Specie = newSpecie;
                _patientRepository.UpdatePatientSpecie(newSpecie);
                Console.WriteLine("Patient specie updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating patient specie: {ex.Message}");
            }
        }

        public static void UpdatePatientRace(string id, string newRace)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newRace))
            {
                Console.WriteLine("Invalid Id or Specie");
                return;
            }

            try
            {
                var patient = _patientRepository.GetById(id);
                if (patient == null)
                {
                    Console.WriteLine("Patient not found.");
                    return;
                }

                patient.Race = newRace;
                _patientRepository.UpdatePatientSpecie(newRace);
                Console.WriteLine("Patient specie updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating patient specie: {ex.Message}");
            }

        }

        public static void DeletePatient(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                Console.WriteLine("Invalid Id");
                return;
            }

            try
            {
                var patient = _patientRepository.GetById(id);
                if (patient == null)
                {
                    Console.WriteLine("Patient not found.");
                    return;
                }

                _patientRepository.Remove(id);
                Console.WriteLine("Patient deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting patient: {ex.Message}");
            }

        }
    }
}

