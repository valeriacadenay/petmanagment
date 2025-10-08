namespace petmanagment.Models
{
    public class Patient : Animal
    {
        
        public Patient(string Name, int Age, string Specie, string race, string ownerIdentification)
            : base(Name, Age, Specie, race, ownerIdentification)
        {
            
        }

        public override void ShowInformation()
        {
            Console.WriteLine($"Name: {this.Name}, Age {this.Age}, Specie {this.Specie}, Race {this.Race}, OwnerIdentification {this.OwnerIdentification}");
        }

        public override void EmitSound()
        {
            switch (Specie.ToLower())
            {
                case "dog":
                    Console.WriteLine("Guau");
                    break;
                case "cat":
                    Console.WriteLine("Miau");
                    break;
                case "bird":
                    Console.WriteLine("Pío pío");
                    break;
                case "cow":
                    Console.WriteLine("Muuuu - Muuuu");
                    break;
                default:
                    Console.WriteLine("Sound unknown to this species.");
                    break;
            }
        }
    }
}