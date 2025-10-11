namespace petmanagment.Models

{
    public class Owner : Person
    {
        public List<Patient> Pets { get; set; } = []; 
        public Owner(
            string name, 
            string lastName, 
            string identification, 
            string email, 
            string phone, 
            int age) : base(name, lastName, identification, email, phone, age)
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