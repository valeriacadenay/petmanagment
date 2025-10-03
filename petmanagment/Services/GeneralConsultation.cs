using petmanagment.Models;

namespace petmanagment.Services;
//Herencia de general Consulting Base logica
public class GeneralConsultation : GeneralConsulting
{
    public GeneralConsultation(Patient patient, string veterinarianName, string reason, string symptoms)
        : base(patient, veterinarianName, reason, symptoms)
    {
    }

    public override void Attend()
    {
        Console.WriteLine($"Atendiendo al paciente: {Patient.Name}");
        Console.WriteLine($"Razón de la visita: {ReasonForVisit}");
        Console.WriteLine($"Síntomas: {Symptoms}");
        Console.WriteLine("Consulta general realizada exitosamente.");
    }
}