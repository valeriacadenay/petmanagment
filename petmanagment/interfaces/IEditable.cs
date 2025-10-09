namespace petmanagment.Interfaces;

public interface IEditable <T>
{
    void Edit(string identification, T entity);
}