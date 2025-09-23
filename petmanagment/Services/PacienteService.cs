using petmanagment.Models;

namespace petmanagment.Services;

public class PacienteService
{
   public static void RegistrarPaciente(List<Paciente> listaPacientes)
   {
      try
      {
         Console.WriteLine("Name of the pacient");
         string name = Console.ReadLine();
         if (string.IsNullOrWhiteSpace(name))
         {
            Console.WriteLine("The name cannot be empty");
            return;
         }

         Console.WriteLine("Age");
         if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
         {
            Console.WriteLine("Enter a valid age");
            return;
         }


         Console.WriteLine("Symptoms of the pacient");
         string symptons = Console.ReadLine();
         if (string.IsNullOrWhiteSpace(symptons))
         {
            Console.WriteLine("The symptoms cannot be empty");
            return;
         }

         Paciente newPacient = new Paciente()
         {
            Id = Guid.NewGuid(),
            Name = name,
            Age = age,
            Symptoms = symptons
         };
         listaPacientes.Add(newPacient);
         Console.WriteLine("Registered patient");
      }
      catch (Exception ex)
      {
         Console.WriteLine(ex.Message);
      }
   }

   public static void ListarPacientes(List<Paciente> listaPacientes)
   {
      if (listaPacientes.Count == 0)
      {
         Console.WriteLine("there are no pacients registered");
      }
      Console.WriteLine("List of pacients:");
      foreach (var pacient in listaPacientes)
      {
         Console.WriteLine(pacient);
      }
   }

   public static void BuscarPacientePorNombre(List<Paciente> listaPacientes, string name)
   {
      var pacient = listaPacientes.FirstOrDefault( p => p.Name == name);
      if (pacient != null)
      {
         Console.WriteLine($"Paciente {name}: {pacient.Id}");
      }
      else
      {
         Console.WriteLine("pacient not found");
      }
   }
        
}