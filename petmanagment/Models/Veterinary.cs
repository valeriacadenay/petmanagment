namespace petmanagment.Models;

public class Veterinary : Person
{
    public string ProfessionalLicense { get; set; } 
    public string Specialty { get; set; } 
    public int YearsOfExperience { get; set; }

    public Veterinary(string name,
        string lastName,
        string identification,
        string email,
        string phone,
        int age,
        string professionalLicense,
        string specialty,
        int yearsOfExperience)
        : base(name, lastName, identification, email, phone, age)
    {
        this.ProfessionalLicense = professionalLicense;
        this.Specialty = specialty;
        this.YearsOfExperience = yearsOfExperience;
    }
    
    public override void ShowInformation()
    {
        base.ShowInformation();
        Console.WriteLine($"Name: {Name} {LastName} License: {ProfessionalLicense}, Specialty: {Specialty}, Experience: {YearsOfExperience} years");
    }
    
}