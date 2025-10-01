namespace petmanagment.Models
{
    public class Patient : Animal
    {
        public Owner Owner { get; set; }
        
        public Patient(string Name, int Age, string Specie, string Race,string symptoms , Owner owner)
            : base(Name, Age, Specie, Race, symptoms)
        {
            Owner = owner;
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