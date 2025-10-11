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
        return DataBase.Services;
    }
    
    public ServiceVeterinary? GetById(Guid id)
    {
        return DataBase.Services.Find(service => service.Id == id);
    }

    public void CreateService(ServiceVeterinary service)
    {
        DataBase.Services.Add(service);
    }

    public void UpdateService(ServiceVeterinary service, string id)
    {
        DataBase.Services = DataBase.Services.Select((serv => serv.Id.ToString() == id ? service : serv)).ToList();
    }

    public void Delete(Guid id)
    {
        DataBase.Services = DataBase.Services.Where((serv => serv.Id == id)).ToList();
    }
}