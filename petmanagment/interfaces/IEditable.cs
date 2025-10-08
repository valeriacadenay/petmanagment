namespace petmanagment.Interfaces;

public interface IEditable <T>
{
    void Edit(string id, T entity);
}