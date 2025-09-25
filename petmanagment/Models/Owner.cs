namespace petmanagment.Models
{
    public class Owner : Person
    {
        public string Email { get; set; }
        public string Phone { get; set; }

        public Owner(string Name, string lastName, int age, string email, string Phone) : base(Name, lastName, age)
        {
            this.Email = email;
            this.Phone = Phone;
        }
        
    }
}