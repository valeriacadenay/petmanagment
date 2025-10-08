namespace petmanagment.Models;

public class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Identification { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int Age { get; set; }
    
    public Person(string name, string lastName, string identification, string email, string phone, int age)
    {
        Id = Guid.NewGuid();
        this.Name = name;
        this.LastName = lastName;
        this.Identification = identification;
        this.Email = email;
        this.Phone = phone;
        this.Age = age;
    }

    public virtual void ShowInformation()
    {
        Console.WriteLine($"Name: {this.Name} {this.LastName}, Identification: {this.Identification}, Email: {this.Email}, Phone: {this.Phone}");
    }
}