using petmanagment.Interfaces;

namespace petmanagment.Services;

public class Vaccination : IAtendible
{
    public void Attend()
    {
        Console.WriteLine("Aplicando vacunación al paciente.");
    }
}