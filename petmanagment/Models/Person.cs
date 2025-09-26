namespace petmanagment.Models;

public class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    
    public Person(string name, int age)
    {
        Id = Guid.NewGuid();
        this.Name = name;
        this.Age = age;
    }
}