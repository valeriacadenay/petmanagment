namespace petmanagment.Services;

public class GeneralConsultation : VeterinaryService
{
    public override void Attend()
    {
        Console.WriteLine("Realizando consulta general al paciente.");
    }
}