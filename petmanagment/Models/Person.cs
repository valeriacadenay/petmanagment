namespace petmanagment.Models;

public class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    
    public Person(string name, string lastName, int age)
    {
        Id = Guid.NewGuid();
        this.Name = name;
        this.LastName = lastName;
        this.Age = age;
    }
}