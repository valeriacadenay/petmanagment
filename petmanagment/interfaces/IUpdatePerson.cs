namespace petmanagment.Interfaces;

public interface IUpdatePerson
{
    public void UpdateOwnerName(string newName);
    public void UpdateOwnerLastName(string LastName);
    public void updateOwnerIdentification(string identification);
    public void updateOwnerEmail(string email);
    public void updateOwnerPhone(string phone);
    public void updateOwnerAge(int age);
}