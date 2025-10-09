namespace petmanagment.Models
{
    public class ServiceVeterinary
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Veterinary Veterinary { get; set; }
        public Patient Patient { get; set; }
        public DateTime ServiceDate { get; set; }
        public decimal Cost { get; set; }
        public string ReasonForVisit { get; set; }
        public string Symptoms { get; set; }

        public ServiceVeterinary(string Name,
            Patient patient,
            Veterinary veterinary,
            DateTime serviceDate,
            decimal cost,
            string reasonForVisit,
            string symptoms)
        {
            Id = Guid.NewGuid();
            this.Name = Name;
            Veterinary = veterinary;
            Patient = patient;
            ServiceDate = serviceDate;
            Cost = cost;
            ReasonForVisit = reasonForVisit;
            Symptoms = symptoms;
        }
        public void ShowInformation()
        {
            Console.WriteLine($"Consulta con: {Veterinary.Name} {Veterinary.LastName}");
            Console.WriteLine($"Paciente: {Patient.Name}");
            Console.WriteLine($"Motivo: {ReasonForVisit}");
            Console.WriteLine($"Síntomas: {Symptoms}");
            Console.WriteLine($"Fecha: {ServiceDate}");
            Console.WriteLine($"Costo: {Cost:C}");
        }
    }
}