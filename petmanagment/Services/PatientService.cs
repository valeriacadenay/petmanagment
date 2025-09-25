using petmanagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace petmanagment.Services
{
    public class PatientService
    {
        public static void RegisterPatient(List<Patient> patientList)
        {
            try
            {
                Console.Write("Enter patient's first name: ");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty");
                    return;
                }

                Console.Write("Enter patient's last name: ");
                string lastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    Console.WriteLine("Last name cannot be empty");
                    return;
                }

                Console.Write("Enter patient's age: ");
                if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
                {
                    Console.WriteLine("Please enter a valid age");
                    return;
                }

                Console.Write("Enter patient's specie: ");
                string specie = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(specie))
                {
                    Console.WriteLine("Specie cannot be empty");
                    return;
                }

                Console.Write("Enter patient's race: ");
                string race = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(race))
                {
                    Console.WriteLine("Race cannot be empty");
                    return;
                }

                Console.Write("Enter patient's symptoms: ");
                string symptoms = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(symptoms))
                {
                    Console.WriteLine("Symptoms cannot be empty");
                    return;
                }

                Patient newPatient = new Patient(name, lastName, age, specie, race, symptoms);

                patientList.Add(newPatient);
                Console.WriteLine("Patient registered successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

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
                Console.WriteLine($"{patient.Name} {patient.LastName}, Age: {patient.Age}, Specie: {patient.Specie}, Race: {patient.Race}, Symptoms: {patient.Symptoms}");
            }
        }

        public static void SearchPatientByName(List<Patient> listaPacientes, string name)
        {
            var patient = listaPacientes.FirstOrDefault(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
            if (patient != null)
            {
                Console.WriteLine($"Patient found: {patient.Name} {patient.LastName}, Age: {patient.Age}");
            }
            else
            {
                Console.WriteLine("Patient not found");
            }
        }
    }
}
