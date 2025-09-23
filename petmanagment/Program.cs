
using petmanagment.Models;
using petmanagment.Services;

List<Paciente> pacients = new List<Paciente>();
bool flag = false;

while (!flag)
{
    Console.WriteLine("\n=== MENU ===");
    Console.WriteLine("1. Register patient");
    Console.WriteLine("2. List patients");
    Console.WriteLine("3. Search for patient");
    Console.WriteLine("4. Exit");
    Console.Write("Select an option: ");
    
    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            PacienteService.RegistrarPaciente(pacients);
            break;
        case "2":
            PacienteService.ListarPacientes(pacients);
            break;
        case "3":
            Console.Write("Enter the name of the pacient ");
            string name = Console.ReadLine();
            PacienteService.BuscarPacientePorNombre(pacients, name);
            break;
        case "4":
            flag = true;
            Console.WriteLine("Leaving the system ... ");
            break;
        default:
            Console.WriteLine("Please input a valid option, try again");
            break;
    }
    
}