namespace petmanagment.Models;

public class Animal(string name, int age, string specie, string race, string symptoms)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
    public string Specie { get; set; } = specie;
    public string Race { get; set; } = race;
    public string Symptoms { get; set; } = symptoms;
    
    public virtual void EmitSound()
    {
        Console.WriteLine("The animal makes a generic sound : ");
    }
}

