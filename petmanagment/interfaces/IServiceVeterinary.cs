using petmanagment.Models;

namespace petmanagment.Interfaces;

public interface IServiceVeterinary
{
    List<ServiceVeterinary> GetAll();
    ServiceVeterinary? GetById(Guid id);
    void CreateService(ServiceVeterinary service);
    void UpdateService(ServiceVeterinary service, string id);
    void Delete(Guid id);
    
}