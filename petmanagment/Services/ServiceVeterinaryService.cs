using petmanagment.Enum;
using petmanagment.Models;
using petmanagment.Repositories;

namespace petmanagment.Services;

public class ServiceVeterinaryService
{
    private static ServiceVeterinaryRepository _veterinaryService = new ServiceVeterinaryRepository();
    
    public void CreateServiceVeterinary(string servicesType,
                                        Patient patient,
                                        Veterinary veterinary,
                                        DateTime serviceDate,
                                        decimal cost,
                                        string reasonForVisit,
                                        string symptoms)
    {
        if (patient == null || veterinary == null || serviceDate == null ||
            cost <= 0 || string.IsNullOrEmpty(reasonForVisit) || string.IsNullOrEmpty(symptoms))
        {
            Console.WriteLine("Invalid input. Please provide valid service details.");
            return;
        }

        try
        {
            ServiceVeterinary newService = new ServiceVeterinary(servicesType, patient, veterinary, serviceDate, cost, reasonForVisit, symptoms);
            _veterinaryService.CreateService(newService);
            Console.WriteLine("Service created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating service: {ex.Message}");
        }
    }
    public List<ServiceVeterinary> GetServices()
    {
        try
        {
            return _veterinaryService.GetAll();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving services: {ex.Message}");
            return new List<ServiceVeterinary>();
        }   
    }
    public ServiceVeterinary? GetServiceById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
           Console.WriteLine("Invalid Id");
           return null;
        }
        try
        {
            return _veterinaryService.GetById(Guid.Parse(id));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving service: {ex.Message}");
            return null;
        }   
    }
    
    public void UpdateService(ServiceVeterinary service, string id)
    {
        if (service == null || string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid input. Please provide valid service details.");
            return;
        }

        try
        {
            _veterinaryService.UpdateService(service, id);
            Console.WriteLine("Service updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating service: {ex.Message}");
        }
    }
    public void DeleteService(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        try
        {
            _veterinaryService.Delete(Guid.Parse(id));
            Console.WriteLine("Service deleted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting service: {ex.Message}");
        }
    }
    
    
}