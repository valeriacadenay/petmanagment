namespace petmanagment.Models;

public class Animal(string name, int age, string specie, string race, string ownerIdentification)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
    public string Specie { get; set; } = specie;
    public string Race { get; set; } = race;

    public string OwnerIdentification { get; set; } = ownerIdentification;

    public virtual void ShowInformation()
    {
        Console.WriteLine($"Name: {this.Name}, Age {this.Age}, Specie {this.Specie}, Race {this.Race}, OwnerIdentification {this.OwnerIdentification}");
    }
    public virtual void EmitSound()
    {
        Console.WriteLine("The animal makes a generic sound : ");
    }
}

