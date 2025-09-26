using petmanagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace petmanagment.Services
{
    public class PatientService
    {
        public static void RegisterPatient(Dictionary<int, Patient> patientDict, List<Owner> owners, ref int patientIdCounter)
        {
            try
            {
                // Data of the pacient
                Console.Write("Enter patient's first name: ");
                string name = Console.ReadLine();

                Console.Write("Enter patient's age: ");
                if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
                {
                    Console.WriteLine("Please enter a valid age");
                    return;
                }

                Console.Write("Enter patient's specie: ");
                string specie = Console.ReadLine();

                Console.Write("Enter patient's race: ");
                string race = Console.ReadLine();

                Console.Write("Enter patient's symptoms: ");
                string symptoms = Console.ReadLine();

                // Data of the owner
                
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("       Enter owner's information:");

                Console.Write("Owner's first name: ");
                string ownerName = Console.ReadLine();

                Console.Write("Owner's last name: ");
                string ownerLastName = Console.ReadLine();

                Console.Write("Owner's age: ");
                int.TryParse(Console.ReadLine(), out int ownerAge);

                Console.Write("Owner's email: ");
                string ownerEmail = Console.ReadLine();

                Console.Write("Owner's phone: ");
                string ownerPhone = Console.ReadLine();

                // Verify if the owner already exist
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

                // Create and add a new patient
                Patient newPatient = new Patient(name, age, specie, race, symptoms, owner);
                int newPatientId = patientIdCounter++;
                patientDict[newPatientId] = newPatient;

                Console.WriteLine($"Patient registered successfully with ID: {newPatientId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }



        public static void ListPatients(Dictionary<int, Patient> patientDict)
        {
            if (patientDict.Count == 0)
            {
                Console.WriteLine("There are no patients registered.");
                return;
            }

            Console.WriteLine("List of patients:");
            foreach (var p in patientDict)
            {
                Patient patient = p.Value;

                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine($"Patient Name: {patient.Name}");
                Console.WriteLine($"Age: {patient.Age}");
                Console.WriteLine($"Specie: {patient.Specie}");
                Console.WriteLine($"Race: {patient.Race}");
                Console.WriteLine($"Symptoms: {patient.Symptoms}");

                if (patient.Owner != null)
                {
                    Console.WriteLine("--- Owner Information ---");
                    Console.WriteLine($"Name: {patient.Owner.Name} {patient.Owner.LastName}");
                    Console.WriteLine($"Age: {patient.Owner.Age}");
                    Console.WriteLine($"Email: {patient.Owner.Email}");
                    Console.WriteLine($"Phone: {patient.Owner.Phone}");
                }
                else
                {
                    Console.WriteLine("Owner information not available.");
                }
            }
            Console.WriteLine("-------------------------------------------------");
        }



        public static void SearchPatientById(Dictionary<int, Patient> patientDict, int id)
        {
            if (patientDict.TryGetValue(id, out Patient patient))
            {
                Console.WriteLine($"Patient found: {patient.Name}, Age: {patient.Age}");
                Console.WriteLine($"Specie: {patient.Specie}, Race: {patient.Race}");
                Console.WriteLine($"Symptoms: {patient.Symptoms}");

                if (patient.Owner != null)
                {
                    Console.WriteLine("--- Owner Information ---");
                    Console.WriteLine($"Name: {patient.Owner.Name} {patient.Owner.LastName}");
                    Console.WriteLine($"Email: {patient.Owner.Email}");
                    Console.WriteLine($"Phone: {patient.Owner.Phone}");
                }
            }
            else
            {
                Console.WriteLine("Patient not found with that ID.");
            }
        }

        public static void SearchPatientByAgeOrSpecies(Dictionary<int, Patient> patientDict, int? edad = null, string especie = null)
        {
            var resultado = patientDict.Where(p => 
                (!edad.HasValue || p.Value.Age == edad.Value) &&
                (string.IsNullOrEmpty(especie) || p.Value.Specie.Equals(especie, StringComparison.OrdinalIgnoreCase))
            );

            if (!resultado.Any())
            {
                Console.WriteLine("No patients found with the given criteria.");
                return;
            }

            foreach(var paciente in resultado)
            {
                Console.WriteLine($"Nombre: {paciente.Value.Name}, Edad: {paciente.Value.Age}, Especie: {paciente.Value.Specie}");
            }
        }
        
    }
}
