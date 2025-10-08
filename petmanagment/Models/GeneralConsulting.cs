using petmanagment.Services;

namespace petmanagment.Models;

public abstract class GeneralConsulting : VeterinaryService
{
    public Patient Patient { get; set; }
    public string ReasonForVisit { get; set; }
    public string Symptoms { get; set; }

    public GeneralConsulting(Patient patient, string veterinarianName, string reason, string symptoms)
    {
        this.Patient = patient;
        this.ReasonForVisit = reason;
        this.Symptoms = symptoms;
        this.ServiceDate = DateTime.Now;
        this.Cost = 150.00m;
    }

}