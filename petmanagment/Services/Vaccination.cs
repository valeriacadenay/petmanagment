namespace petmanagment.Services;

public class Vaccination : VeterinaryService
{
    public override void Attend()
    {
        Console.WriteLine("Aplicando vacunación al paciente.");
    }
}