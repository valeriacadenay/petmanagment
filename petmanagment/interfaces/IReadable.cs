namespace petmanagment.Interfaces;

public interface IReadable <T>
{
        List<T> GetAll();
        T? GetById(string id);
        T? GetByName(string name);
}