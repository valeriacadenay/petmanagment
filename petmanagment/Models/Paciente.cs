namespace petmanagment.Models;

public class Paciente
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Symptoms { get; set; }
    
    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Age: {Age}, Symptoms: {Symptoms}";
    }

}