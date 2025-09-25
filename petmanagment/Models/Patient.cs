namespace petmanagment.Models
{
    public class Patient : Person 
    {
        public string Specie { get; set; }
        public string Race { get; set; }
        public string Symptoms { get; set; }

        public Patient(string name, string lastName, int age, string specie, string race, string symptoms)
            : base(name, lastName, age)
        {
            this.Specie = specie;
            this.Race = race;
            this.Symptoms = symptoms;
        }
    }
}