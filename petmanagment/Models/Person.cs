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
        Name = name;
        LastName = lastName;
        Identification = identification;
        Email = email;
        Phone = phone;
        Age = age;
    }

    public virtual void ShowInformation()
    {
        Console.WriteLine(
            $"Name: {Name} {LastName}, Identification: {Identification}, Email: {Email}, Phone: {Phone}");
    }
}