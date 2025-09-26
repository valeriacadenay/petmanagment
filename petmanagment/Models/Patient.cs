namespace petmanagment.Models
{
    public class Patient : Person 
    {
        public string Specie { get; set; }
        public string Race { get; set; }
        public string Symptoms { get; set; }
        public Owner Owner { get; set; }

        public Patient(string name, int age, string specie, string race, string symptoms,Owner owner)
            : base(name, age)
        {
            this.Specie = specie;
            this.Race = race;
            this.Symptoms = symptoms;
            Owner = owner;
        }
    }
}