using petmanagment.Interfaces;
using petmanagment.Models;
using petmanagment.Data;

namespace petmanagment.Repositories;

public class ServiceVeterinaryRepository : IServiceVeterinary 
{
    public ServiceVeterinaryRepository()
    {
    }
    
    public List<ServiceVeterinary> GetAll()
    {
        return DataBase.services;
    }
    
    public ServiceVeterinary? GetById(Guid id)
    {
        return DataBase.services.Find(service => service.Id == id);
    }

    public void CreateService(ServiceVeterinary service)
    {
        DataBase.services.Add(service);
    }

    public void UpdateService(ServiceVeterinary service, string id)
    {
        DataBase.services = DataBase.services.Select((serv => serv.Id.ToString() == id ? service : serv)).ToList();
    }

    public void Delete(Guid id)
    {
        DataBase.services = DataBase.services.Where((serv => serv.Id == id)).ToList();
    }
}