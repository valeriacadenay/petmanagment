namespace petmanagment.Models

{
    public class Owner : Person
    {
        public List<Patient> Pets { get; set; } = new(); 

        public Owner(string Name, string lastName, string identification,int age, string email, string Phone) : base(Name, lastName, identification, email, Phone, age)
        {
            
        }
        public void ShowPets()
        {
            Console.WriteLine($"Pets of {this.Name}:");
            if (this.Pets.Count == 0)
            {
                Console.WriteLine("The user doesn't have any pet ");
                return;
            }

            foreach (var pet in this.Pets)
            {
                Console.Write(" ------------------------------");
                pet.ShowInformation();
                
            }
        }

        public void addPet(Patient pet)
        {
            this.Pets.Add(pet);
        }

        public void removePet(string id)
        {
            this.Pets = this.Pets.Where((pet) => !pet.Id.Equals(id)).ToList();
        }
    }
}